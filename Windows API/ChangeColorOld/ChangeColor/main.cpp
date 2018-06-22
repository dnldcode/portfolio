#include <Windows.h>
#include <string>
#include "resource.h"

using namespace std;

BOOL CALLBACK Color1DlgProc(HWND, UINT, WPARAM, LPARAM);
BOOL CALLBACK Color2DlgProc(HWND, UINT, WPARAM, LPARAM);
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hInstPrev, LPSTR lpCmdLine, int nCmdShow)// LP - LongPointer(������ �� ������), H - Handle
{
	HWND hWnd;//HW - Handler for Windows
	MSG msg;
	WNDCLASSEX wc;// ��������� ������� ��������� ����
	TCHAR szClassName[] = TEXT("Main");// sz - string zero;�������� ����

	//������������ ����

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

	// ����������� ������

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
	//���� ��������� ���������
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
	case WM_COMMAND:

		switch (LOWORD(wParam))
		{
		case IDM_EXIT:
			SendMessage(hWnd, WM_DESTROY, 0, 0);
			break;
		case IDM_COLOR1:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_DIAG1), hWnd, Color1DlgProc);
			break;
		/*case IDM_COLOR2:
			DialogBox(hInst2, MAKEINTRESOURCE(IDD_DIAG2), hWnd, Color2DlgProc);
			break;*/
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
	HWND hParent;// ���������� �������� ���� ������ ����������

	switch (uMsg)
	{
	case WM_INITDIALOG:
		hEred = GetDlgItem(hDlg, IDC_EDRED);// ��������� ����������
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
				MessageBox(NULL, TEXT("������. �������� ������ �� 0 �� 256"), TEXT("Error"), MB_OK);
			else
			{
				hParent = GetParent(hDlg);// ��������� ����������� ��������
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