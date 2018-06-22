#include <Windows.h>
#include <string>
#include "resource.h"

using namespace std;

BOOL CALLBACK Color1DlgProc(HWND, UINT, WPARAM, LPARAM);
BOOL CALLBACK Color2DlgProc(HWND, UINT, WPARAM, LPARAM);
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
int rgb[3];
enum UserMsg
{
	UM_CHANGE = WM_USER + 1
};

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hInstPrev, LPSTR lpCmdLine, int nCmdShow)// LP - LongPointer(указат на данные), H - Handle
{
	HWND hWnd;//HW - Handler for Windows
	MSG msg;
	WNDCLASSEX wc;// структура которая описывает окно
	TCHAR szClassName[] = TEXT("Main");// sz - string zero;название окна

	//Иницилизация окна

	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS;
	wc.lpfnWndProc = WndProc;
	wc.cbWndExtra = 0;
	wc.cbClsExtra = 0;
	wc.hInstance = hInst;
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName = MAKEINTRESOURCE(IDR_MENU1);
	wc.lpszClassName = szClassName;
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	// Регистрация класса

	if (!RegisterClassEx(&wc))
	{
		MessageBox(NULL, TEXT("Register failure"), TEXT("Error"), MB_OK);
		return 0;
	}
	hWnd = CreateWindow(szClassName, TEXT("Window"), WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, NULL, NULL, hInst, NULL);
	if (!hWnd)
	{
		MessageBox(NULL, TEXT("Create windows failure"), TEXT("Error"), MB_OK);
		return 0;
	}
	ShowWindow(hWnd, nCmdShow);
	//Цикл обработки сообщений
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
};

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;// Handler device context
	PAINTSTRUCT psPaint;
	static HINSTANCE hInst;

	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		hInst = GetModuleHandle(NULL);
		break;
	case WM_PAINT:
		BeginPaint(hWnd, &psPaint);
		EndPaint(hWnd, &psPaint);
		break;
	case UM_CHANGE:
		SetClassLong(hWnd, GCL_HBRBACKGROUND, (LONG)CreateSolidBrush(RGB(rgb[0], rgb[1], rgb[2])));
		InvalidateRect(hWnd, NULL, true);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDM_EXIT:
			SendMessage(hWnd, WM_DESTROY, 0, 0);
			break;
		case IDM_COLOR1:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_DIAG1), hWnd, Color1DlgProc);
			break;
		case IDM_COLOR2:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_DIAG2), hWnd, Color2DlgProc);
			break;
		default:
			break;
		}
		InvalidateRect(hWnd, NULL, true);
		break;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	return 0;
}

BOOL CALLBACK Color1DlgProc(HWND hDlg, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	static HWND hEred, hEgreen, hEblue;
	static HBRUSH hBrush;
	static TCHAR tRed[4], tGreen[4], tBlue[4];
	static int nRed, nGreen, nBlue;
	BOOL flag;
	HWND hParent;// Дескриптор главного окна нашего приложения

	switch (uMsg)
	{
	case WM_INITDIALOG:
		hEred = GetDlgItem(hDlg, IDC_EDRED);// Извлекаем дескриптор
		hEgreen = GetDlgItem(hDlg, IDC_EDGREEN);
		hEblue = GetDlgItem(hDlg, IDC_EDBLUE);
		SetDlgItemText(hDlg, IDC_EDRED, TEXT("0"));
		SetDlgItemText(hDlg, IDC_EDGREEN, TEXT("0"));
		SetDlgItemText(hDlg, IDC_EDBLUE, TEXT("0"));
		return true;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
			nRed = GetDlgItemInt(hDlg, IDC_EDRED, &flag, false);
			nGreen = GetDlgItemInt(hDlg, IDC_EDGREEN, &flag, false);
			nBlue = GetDlgItemInt(hDlg, IDC_EDBLUE, &flag, false);
			if (!(nRed >= 0 && nRed <= 255 && nGreen >= 0 && nGreen <= 255 && nBlue >= 0 && nBlue <= 255))
				MessageBox(NULL, TEXT("Ошибка. Диапазон данных от 0 до 256"), TEXT("Error"), MB_OK);
			else
			{
				hParent = GetParent(hDlg);// Получение дескриптора родителя
				SetClassLong(hParent, GCL_HBRBACKGROUND, (LONG)CreateSolidBrush(RGB(nRed, nGreen, nBlue)));
				EndDialog(hDlg, 0);
			}
			return true;
		case IDCANCEL:
			EndDialog(hDlg, 0);
			return true;
		default:
			return true;
		}
		return true;
	}
	return false;
}
BOOL CALLBACK Color2DlgProc(HWND hDlg, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	static HWND hParent, hRedSb, hGreenSb, hBlueSb;
	int nCtrlId, index;
	HWND hCtrl;
	static HWND hSt1, hSt2, hSt3;
	static LOGFONT lf;
	HFONT hFont;
	static HWND hStRed, hStGreen, hStBlue;
	TCHAR text[5];

	switch (uMsg)
	{
	case WM_INITDIALOG:
		hRedSb = GetDlgItem(hDlg, IDC_SBBRED);
		hGreenSb = GetDlgItem(hDlg, IDC_SBBGREEN);
		hBlueSb = GetDlgItem(hDlg, IDC_SBBBLUE);

		hSt1 = GetDlgItem(hDlg, IDC_CRED);
		hSt2 = GetDlgItem(hDlg, IDC_CGREEN);
		hSt3 = GetDlgItem(hDlg, IDC_CBLUE);

		hStRed = GetDlgItem(hDlg, IDC_SBSTATICRED);
		hStGreen = GetDlgItem(hDlg, IDC_SBSTATICGREEN);
		hStBlue = GetDlgItem(hDlg, IDC_SBSTATICBLUE);

		lf.lfHeight = 16;
		lstrcpy((LPWSTR)&lf.lfFaceName, TEXT("Verdana"));
		hFont = CreateFontIndirect(&lf);
		SendMessage(hSt1, WM_SETFONT, (WPARAM)hFont, true);
		SendMessage(hSt2, WM_SETFONT, (WPARAM)hFont, true);
		SendMessage(hSt3, WM_SETFONT, (WPARAM)hFont, true);

		SetScrollRange(hRedSb, SB_CTL, 0, 255, FALSE);// от 0 до 255
		SetScrollPos(hRedSb, SB_CTL, 0, false);// выставляем по центру
		SetScrollRange(hGreenSb, SB_CTL, 0, 255, FALSE);
		SetScrollPos(hGreenSb, SB_CTL, 0, false);
		SetScrollRange(hBlueSb, SB_CTL, 0, 255, FALSE);
		SetScrollPos(hBlueSb, SB_CTL, 0, false);
		return true;
	case WM_VSCROLL:
		hCtrl = (HWND)lParam;
		nCtrlId = GetDlgCtrlID(hCtrl);
		index = nCtrlId - IDC_SBBGREEN;
		switch (LOWORD(wParam))
		{
		case SB_LINEUP:
			rgb[index] = max(0, rgb[index] - 1);
			break;
		case SB_LINEDOWN:
			rgb[index] = min(255, rgb[index] + 1);
			break;
		case SB_PAGEUP:
			rgb[index] -= 15;
			break;
		case SB_PAGEDOWN:
			rgb[index] += 15;
			break;
		case SB_THUMBTRACK:
			rgb[index] = HIWORD(wParam);
			break;
		default:
			break;
		}
		wsprintf(text, TEXT("%d"), rgb[index]);
		if (index == 0)
			SetWindowText(hStRed, text);
		else if (index == 1)
			SetWindowText(hStGreen, text);
		else
			SetWindowText(hStBlue, text);
		SetScrollPos(hCtrl, SB_CTL, rgb[index], true);
		SendMessage(GetParent(hDlg), UM_CHANGE, 0, 0);
		return true;
	case WM_CTLCOLORSTATIC:
		if ((HWND)lParam == hSt1)
		{
			SetTextColor((HDC)wParam, RGB(255, 0, 0));
			SetBkMode(HDC(wParam), TRANSPARENT);
			return (DWORD)GetSysColorBrush(COLOR_3DFACE);
		}
		if ((HWND)lParam == hSt2)
		{
			SetTextColor((HDC)wParam, RGB(0, 255, 0));
			SetBkMode(HDC(wParam), TRANSPARENT);
			return (DWORD)GetSysColorBrush(COLOR_3DFACE);
		}
		if ((HWND)lParam == hSt3)
		{
			SetTextColor((HDC)wParam, RGB(0, 0, 255));
			SetBkMode(HDC(wParam), TRANSPARENT);
			return (DWORD)GetSysColorBrush(COLOR_3DFACE);
		}
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
			EndDialog(hDlg, 0);
			return true;
		case IDCANCEL:
			EndDialog(hDlg, 0);
			return true;
		default:
			return true;
		}
		return true;
	}
	return false;
}