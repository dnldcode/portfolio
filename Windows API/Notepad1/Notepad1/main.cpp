#include <Windows.h>
#include <string>
#include "resource.h"
#include <io.h>
#include <stdio.h>

using namespace std;

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
static HWND hEdt;
// Структура для работы с открытием
static OPENFILENAME ofn;
static TCHAR filename[MAX_PATH];
static FILE *fdat;
void AdjustWindowSize(HWND hParent, HWND hDlg);
void OfnInitialize(HWND hWnd);

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hInstPrev, LPSTR lpCmdLine, int nCmdShow)// LP - LongPointer(указат на данные), H - Handle
{
	HWND hWnd;//HW - Handler for Windows
	MSG msg;
	WNDCLASSEX wc;// структура которая описывает окно
	TCHAR szClassName[] = TEXT("Main");// sz - string zero;название окна

									   //Иницилизация окна

	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW;
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
	RECT rect;
	PAINTSTRUCT psPaint;
	HINSTANCE hInst = GetModuleHandle(NULL);
	// Структура для окна работы со шрифтом
	static CHOOSEFONT chf;
	static HFONT hFont;
	static LOGFONT lf;
	// Структура для работы с окном выбора цвета
	static CHOOSECOLOR cc;
	static COLORREF color;
	static COLORREF colors[16];

	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		hEdt = CreateWindow(TEXT("edit"), NULL, WS_CHILD | WS_VISIBLE | WS_HSCROLL
			| WS_VSCROLL | WS_BORDER | ES_LEFT
			| ES_MULTILINE | ES_AUTOHSCROLL | ES_AUTOVSCROLL
			| ES_WANTRETURN, 0, 0, 100, 100, hWnd, (HMENU)NULL, hInst, NULL);// Функция создает окно
		//ofn
		OfnInitialize(hWnd);
		//Иницилизация структуры для работы со шрифтом
		chf.lStructSize = sizeof(CHOOSEFONT);
		chf.hwndOwner = hWnd;
		chf.lpLogFont = &lf;
		chf.Flags = CF_SCREENFONTS | CF_INITTOLOGFONTSTRUCT;
		chf.nFontType = SIMULATED_FONTTYPE;
		break;
	case WM_PAINT:
		BeginPaint(hWnd, &psPaint);

		EndPaint(hWnd, &psPaint);
		break;
	case WM_SIZE:
		AdjustWindowSize(hWnd, hEdt);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDM_NEW:

			break;
		case IDM_OPEN:
			if (GetOpenFileName(&ofn))
			{
				char filenameChar[MAX_PATH] = "";
				long len = lstrlen(ofn.lpstrFile);
				WideCharToMultiByte(CP_ACP, 0, ofn.lpstrFile, -1, filenameChar, len, 0, 0);
				fdat = fopen(filenameChar, "rb");
				if (fdat)
				{
					int fd = _fileno(fdat);
					len = _filelength(fd);
					if (len > 1)
					{
						char *nBuf = new char[len];
						TCHAR *wBuf = new TCHAR[len];
						fread(nBuf, sizeof(char), len, fdat);
						MultiByteToWideChar(CP_ACP, 0, nBuf, -1, wBuf, len);
						SetWindowText(hEdt, wBuf);
						delete[] nBuf;
						delete[] wBuf;
					}
				}
				else
					MessageBox(hWnd, ofn.lpstrFile, TEXT("File open error"), MB_OK);
				fclose(fdat);
			}
			InvalidateRect(hWnd, NULL, true);
			break;
		case IDM_SAVE:
			if (GetSaveFileName(&ofn))
			{
				char filenameChar[MAX_PATH] = "";
				long len = lstrlen(ofn.lpstrFile);
				WideCharToMultiByte(CP_ACP, 0, ofn.lpstrFile, -1, filenameChar, len + 1, 0, 0);
				fdat = fopen(filenameChar, "wb");
				if (fdat)
				{
					len = SendMessage(hEdt, WM_GETTEXTLENGTH, 0, 0);
					TCHAR *wBuf = new TCHAR[len + 1];
					GetWindowText(hEdt, wBuf, len + 1);
					char *nBuf = new char[len + 1];
					WideCharToMultiByte(CP_ACP, 0, wBuf, -1, nBuf, len + 1, NULL, NULL);
					fwrite(nBuf, len, 1, fdat);
				}
				else
					MessageBox(hWnd, ofn.lpstrFile, TEXT("File save error"), MB_OK);

				fclose(fdat);
			}
			InvalidateRect(hWnd, NULL, true);
			break;
		case IDM_EXIT:

			break;
		case IDM_COLOR:

			break;
		case IDM_FONT:
			if (ChooseFont(&chf))
				hFont = CreateFontIndirect(chf.lpLogFont);
			SendMessage(hEdt, WM_SETFONT, (WPARAM)hFont, true);
			break;
		case IDM_ABOUT:

			break;
		default:
			break;
		}
		break;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	return 0;
}
void ShiftWindow(HWND hChild, HWND hParent, int dx, int dy, int dw, int dh)
{
	RECT rect;
	POINT point;
	GetWindowRect(hChild, &rect);
	int width = rect.right - rect.left + dw;
	int height = rect.bottom - rect.top + dh;
	point.x = rect.left + dx;
	point.y = rect.top + dy;
	ScreenToClient(hParent, &point);
	MoveWindow(hChild, point.x, point.y, width - 20, height - 20, true);
}
void AdjustWindowSize(HWND hParent, HWND hDlg)
{
	RECT rcParent, rcDlg;
	GetClientRect(hParent, &rcParent);
	GetClientRect(hDlg, &rcDlg);
	int width = rcDlg.right - rcDlg.left;// Ширина диалогового окна
	int height = rcDlg.bottom - rcDlg.top;// Высота
	int dh = rcParent.bottom - height;
	int dw = rcParent.right - width;
	ShiftWindow(hDlg, hParent, 0, 0, dw, dh);
}
void OfnInitialize(HWND hWnd)
{
	static TCHAR szFilter[] = TEXT("Text Files(*.txt)\0*.txt\0All Files(*.*)\0*.*\0\0");
	ofn.lStructSize = sizeof(OPENFILENAME);
	ofn.hwndOwner = hWnd;
	ofn.hInstance = NULL;
	ofn.lpstrFilter = szFilter;
	ofn.lpstrCustomFilter = NULL;
	ofn.nMaxCustFilter = 0;
	ofn.nFilterIndex = 0;
	ofn.lpstrFile = filename;
	ofn.lpstrFile[0] = '\0';
	ofn.nMaxFile = sizeof(filename);
	ofn.lpstrFileTitle = NULL;
	ofn.nMaxFileTitle = _MAX_FNAME + _MAX_EXT;
	ofn.lpstrInitialDir = NULL;
	ofn.lpstrTitle = NULL;
	ofn.Flags = 0;
	ofn.nFileOffset = 0;
	ofn.nFileExtension = 0;
	ofn.lpstrDefExt = TEXT("txt");
	ofn.lCustData = 0;
	ofn.lpfnHook = NULL;
	ofn.lpTemplateName = NULL;
}