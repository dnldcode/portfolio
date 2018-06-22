#include <Windows.h>
#include <string>
#include <time.h>
#include <math.h>

#define TIME_SEC 1
#define T_START (WM_USER + 1)//Button 1
#define T_END (WM_USER + 2)//Button 2
#define PI 3.141592653589793238462643

using namespace std;

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

TCHAR text[100];
int TIMER_SEC;
RECT clock1;
int centreX, centreY;

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
	wc.hIcon = LoadIcon(hInst, IDI_QUESTION);
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName = NULL;//MAKEINTRESOURCE(IDR_MENU1);
	wc.lpszClassName = szClassName;
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	// Регистрация класса

	if (!RegisterClassEx(&wc))
	{
		MessageBox(NULL, TEXT("Register failure"), TEXT("Error"), MB_OK);
		return 0;
	}
	hWnd = CreateWindow(szClassName, TEXT("Timer"), WS_OVERLAPPED  | WS_SYSMENU, GetSystemMetrics(SM_CXSCREEN)/2 - 150, GetSystemMetrics(SM_CYSCREEN)/2 - 250, 400, 475, NULL, NULL, hInst, NULL);
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
	HBRUSH hBrush, hBrushOld;
	HPEN hPenь, hPenOld;
	static int hh, mm, ss;
	static double hX, hY, mX, mY, sX, sY;

	static HBITMAP hBmp = (HBITMAP)LoadImage(NULL, TEXT("clock.bmp"), IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);

	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		//Making buttons
		CreateWindow(TEXT("BUTTON"), TEXT("Начать"), WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
			50, 350, 125, 50, hWnd, (HMENU)T_START, (HINSTANCE)GetWindowLong(hWnd, GWL_HINSTANCE), NULL);
		CreateWindow(TEXT("BUTTON"), TEXT("Стоп"), WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
			225, 350, 125, 50, hWnd, (HMENU)T_END, (HINSTANCE)GetWindowLong(hWnd, GWL_HINSTANCE), NULL);
		//Picture Rect
		clock1.top = 50;
		clock1.bottom = 300;
		clock1.right = 325;
		clock1.left = 75;
		//Centre
		centreX = 200;
		centreY = 175;
		//Default paint
		mY = 125;
		hY = 135;
		sY = 105;
		hX = mX = sX = 200;//Center

		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &psPaint);
		hBrush = CreatePatternBrush(hBmp);

		SetBrushOrgEx(hDC, 325, 50, NULL);//x = 325, y = 50
		SelectObject(hDC, hBrush);
		FillRect(hDC, &clock1, hBrush);


		SelectObject(hDC, CreatePen(PS_SOLID, 7, RGB(0, 0, 0)));

		MoveToEx(hDC, centreX, centreY, NULL);
		LineTo(hDC, hX, hY);

	
		SelectObject(hDC, CreatePen(PS_SOLID, 7, RGB(0, 0, 0)));

		MoveToEx(hDC, centreX, centreY, NULL);
		LineTo(hDC, mX, mY);

		SelectObject(hDC, CreatePen(PS_SOLID, 5, RGB(0, 0, 0)));

		MoveToEx(hDC, centreX, centreY, NULL);
		LineTo(hDC, sX, sY);


		EndPaint(hWnd, &psPaint);
		break;
	case WM_TIMER:
		wsprintf(text, TEXT("H : %d  M : %d  S : %d"), hh, mm, ss);

		SetWindowText(hWnd, text);//Выводим в заголовок данные таймера
		if (ss == 60)
		{
			ss = 0;
			mm++;
			if (mm == 60)
			{
				mm = 0;
				hh++;
				if (hh == 24)
				{
					hh = 0;
					mm = 0;
					ss = 0;
				}
			}
		}
		// Алгоритм получения координат для стрелок
		hX = centreX + (sin(2 * PI * (hh * 60 + mm) / 12 / 60)) * 40;//Длина 40
		hY = centreY + (-cos(2 * PI * (hh * 60 + mm) / 12 / 60)) * 40;

		mX = centreX + (sin(2 * PI * mm / 60)) * 50;//Длина 50
		mY = centreY + (-cos(2 * PI * mm / 60)) * 50;

		sX = 200 + (sin(2 * PI * ss / 60)) * 70;//Длина 70
		sY = centreY + (-cos(2 * PI * ss / 60)) * 70;
		ss++;

		InvalidateRect(hWnd, NULL, true);
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case T_START:
			if (hh == 0 && mm == 0 && ss == 0)
				SetTimer(hWnd, TIME_SEC, 1000, NULL);
			break;
		case T_END:
			KillTimer(hWnd, TIME_SEC);
			hh = 0;
			mm = 0;
			ss = 0;
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