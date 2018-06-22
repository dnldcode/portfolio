#include <Windows.h>
#include <string>
#include "resource.h"

using namespace std;

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
int r, g, b, gray;
COLORREF pcol;
HANDLE hArr[3];
DWORD WINAPI ThreadA(LPVOID lpv);
DWORD WINAPI ThreadB(LPVOID lpv);
DWORD WINAPI ThreadC(LPVOID lpv);
int w, h;

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
	hWnd = CreateWindow(szClassName, TEXT("Window"), WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 900, 800, NULL, NULL, hInst, NULL);
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
	static HBITMAP hBmp;
	BITMAP bmp;
	HBITMAP hBmpOld;
	HDC hDCMem;
	RECT rect;
	HDC hDC1;
	static HANDLE htA, htB, htC;

	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &psPaint);
		hDCMem = CreateCompatibleDC(hDC);
		hBmpOld = (HBITMAP)SelectObject(hDCMem, hBmp);
		GetObject(hBmp, sizeof(BITMAP), &bmp);// Заносим в bmp информацию из hBmp
		w = bmp.bmWidth;
		h = bmp.bmHeight;
		GetClientRect(hWnd, &rect);
		//StretchBlt(hDC, 0, 0, rect.right, rect.bottom, hDCMem, 0, 0, w, h, SRCCOPY);
		BitBlt(hDC, 0, 0, w, h, hDCMem, 0, 0, SRCCOPY);
		SelectObject(hDCMem, hBmpOld);

		EndPaint(hWnd, &psPaint);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDM_OPEN:
			hBmp = (HBITMAP)LoadImage(GetModuleHandle(NULL), TEXT("1.bmp"), IMAGE_BITMAP,0,0, LR_LOADFROMFILE | LR_DEFAULTSIZE);
			InvalidateRect(hWnd, NULL, true);
			break;
		case IDM_ONE:
			hDC1 = GetDC(hWnd);
			LONG start, end;
			TCHAR time[100];
			start = GetTickCount();
			for (int i = 0;i < w;i++)
			{
				for (int j = 0;j < h;j++)
				{
					pcol = GetPixel(hDC1, i, j);
					r = GetRValue(pcol);
					g = GetBValue(pcol);
					b = GetBValue(pcol);
					gray = (int)(r*0.3 + g*0.59 + b*0.11);
					pcol = RGB(gray, gray, gray);
					SetPixelV(hDC1, i, j, pcol);
				}
			}
			end = GetTickCount();
			wsprintf(time, TEXT("TIME : %d"), end - start);
			MessageBox(NULL, time, TEXT("Error"), MB_OK);
			//InvalidateRect(hWnd, NULL, TRUE);
			break;
		case IDM_MANY:
			hDC1 = GetDC(hWnd);
			htA = CreateThread(NULL, 0, ThreadA, hWnd, 0, NULL);
			htB = CreateThread(NULL, 0, ThreadB, hWnd, 0, NULL);
			htC = CreateThread(NULL, 0, ThreadC, hWnd, 0, NULL);
			//SetThreadPriority(htA, THREAD_PRIORITY_HIGHEST);
			//SetThreadPriority(htB, THREAD_PRIORITY_HIGHEST);
			//SetThreadPriority(htC, THREAD_PRIORITY_HIGHEST);
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
DWORD WINAPI ThreadA(LPVOID lpv)
{
	LONG start, end;
	TCHAR time[100];
	start = GetTickCount();
	HWND hPic = (HWND)lpv;
	HDC hDCloc = GetDC(hPic);
	for (int i = 0;i < w/3;i++)
	{
		for (int j = 0;j < h;j++)
		{
			pcol = GetPixel(hDCloc, i, j);
			r = GetRValue(pcol);
			g = GetBValue(pcol);
			b = GetBValue(pcol);
			gray = (int)(r*0.3 + g*0.59 + b*0.11);
			pcol = RGB(gray, gray, gray);
			SetPixelV(hDCloc, i, j, pcol);
		}
	}
	end = GetTickCount();
	wsprintf(time, TEXT("TIME TA : %d"), end - start);
	MessageBox(NULL, time, TEXT("Error"), MB_OK);

	return 0;
}
DWORD WINAPI ThreadB(LPVOID lpv)
{
	LONG start, end;
	TCHAR time[100];
	start = GetTickCount();
	HWND hPic = (HWND)lpv;
	HDC hDCloc = GetDC(hPic);
	for (int i = w / 3;i < 2 * w / 3;i++)
	{
		for (int j = 0;j < h;j++)
		{
			pcol = GetPixel(hDCloc, i, j);
			r = GetRValue(pcol);
			g = GetBValue(pcol);
			b = GetBValue(pcol);
			gray = (int)(r*0.3 + g*0.59 + b*0.11);
			pcol = RGB(gray, gray, gray);
			SetPixelV(hDCloc, i, j, pcol);
		}
	}
	end = GetTickCount();
	wsprintf(time, TEXT("TIME TB : %d"), end - start);
	MessageBox(NULL, time, TEXT("Error"), MB_OK);
	return 0;
}
DWORD WINAPI ThreadC(LPVOID lpv)
{
	LONG start, end;
	TCHAR time[100];
	start = GetTickCount();
	HWND hPic = (HWND)lpv;
	HDC hDCloc = GetDC(hPic);
	for (int i = (2*w / 3);i < w;i++)
	{
		for (int j = 0;j < h;j++)
		{
			pcol = GetPixel(hDCloc, i, j);
			r = GetRValue(pcol);
			g = GetBValue(pcol);
			b = GetBValue(pcol);
			gray = (int)(r*0.3 + g*0.59 + b*0.11);
			pcol = RGB(gray, gray, gray);
			SetPixelV(hDCloc, i, j, pcol);
		}
	}
	end = GetTickCount();
	wsprintf(time, TEXT("TIME TC : %d"), end - start);
	MessageBox(NULL, time, TEXT("Error"), MB_OK);
	return 0;
}