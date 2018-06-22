////////////////////////////////////////////////////////////
// CWnd.cpp
#include "CWnd.h"

CWnd::CWnd(LPCTSTR windowName, HINSTANCE hInst, int cmdShow,
				   LRESULT (WINAPI *pWndProc)(HWND,UINT,WPARAM,LPARAM),
				   LPCTSTR menuName, int x, int y, int width, int height,
				   UINT classStyle, DWORD windowStyle, HWND hParent)
{
	TCHAR szClassName[] = TEXT("CWndClass");

	wc.cbSize        = sizeof(wc);
	wc.style         = classStyle;
	wc.lpfnWndProc   = pWndProc;
	wc.cbClsExtra	 = 0;
	wc.cbWndExtra    = 0;
	wc.hInstance     = hInst;
	wc.hIcon		 = LoadIcon(NULL, IDI_APPLICATION);
	wc.hCursor       = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName  = menuName;
	wc.lpszClassName = szClassName;
	wc.hIconSm       = LoadIcon(NULL, IDI_APPLICATION);

	// Регистрируем класс окна
	if (!RegisterClassEx(&wc)) 
	{
		TCHAR msg[100] = TEXT("Cannot register class: ");
		wcscat(msg, szClassName);
		MessageBox(NULL, msg, TEXT("Error"), MB_OK);
		return;
	}
	
	// Создаем окно
	hWnd = CreateWindow(szClassName, windowName, windowStyle,
		x, y, width, height, hParent, (HMENU)NULL, hInst, NULL);       
	
	if (!hWnd) 
	{
		TCHAR text[100] = TEXT("Cannot create window: ");
		wcscat(text, windowName);
		MessageBox(NULL, text, TEXT("Error"), MB_OK);
		return;
	}

	// Показываем  окно
	ShowWindow(hWnd, cmdShow); 
}
HWND CWnd::GetHWnd() 
{ 
	return hWnd; 
}