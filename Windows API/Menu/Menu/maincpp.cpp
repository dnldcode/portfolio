#include <Windows.h>
#include <string>
#include "resource1.h"

using namespace std;

BOOL CALLBACK AboutDlgProc(HWND, UINT, WPARAM, LPARAM);
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

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
		hInst = GetModuleHandle(NULL);// Получаем дескриптор нашего приложения
		break;
	case WM_PAINT:
		BeginPaint(hWnd, &psPaint);
		EndPaint(hWnd, &psPaint);
		break;
	case WM_COMMAND:

		switch (LOWORD(wParam))
		{
		case IDM_OPEN:
			MessageBox(hWnd, TEXT("Open"), TEXT("Menu"), MB_OK);
			break;
		case IDM_SAVE:
			MessageBox(hWnd, TEXT("Save"), TEXT("Menu"), MB_OK);
			break;
		case IDM_EXIT:
			SendMessage(hWnd, WM_DESTROY, 0, 0);
			//DestroyWindow(hWnd);
			break;
		case IDM_COLOR:
			MessageBox(hWnd, TEXT("Color"), TEXT("Menu"), MB_OK);
			break;
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUT), hWnd, AboutDlgProc);
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

BOOL CALLBACK AboutDlgProc(HWND hDlg, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch (uMsg)
	{
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:
			EndDialog(hDlg, 0);
			return true;
		}
		return true;
	}
	return false;
}