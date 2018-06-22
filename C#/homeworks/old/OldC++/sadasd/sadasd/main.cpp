
#include <math.h>
#include <conio.h>
#include <windows.h>
#include <stdio.h>

#define MAX_LOADSTRING 100
#define ID_5SECONDS 101 // идентификатор таймера
UINT TimmerID = 0;

// Global Variables:
HINSTANCE hInst;
TCHAR szTitle[MAX_LOADSTRING];
TCHAR szWindowClass[MAX_LOADSTRING];
HBITMAP maskBitmap;
HWND hWnd;
double x = 180, y = 180;



// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY _tWinMain(HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPTSTR    lpCmdLine,
	int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_CLOCK3, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance(hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_CLOCK3));




	int Style;
	Style = GetWindowLong(hWnd, GWL_STYLE);
	Style = Style || WS_CAPTION;
	Style = Style || WS_SYSMENU;
	SetWindowLong(hWnd, GWL_STYLE, Style);
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	// Загружаем картинку
	maskBitmap = (HBITMAP)LoadImage(NULL, L"clock.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);

	if (!maskBitmap) return NULL;

	// Описание необходимых переменных
	BITMAP bi;
	BYTE bpp;
	DWORD TransPixel;
	DWORD pixel;
	int startx;
	INT i, j;

	HRGN Rgn, ResRgn = CreateRectRgn(0, 0, 0, 0);

	GetObject(maskBitmap, sizeof(BITMAP), &bi);

	bpp = bi.bmBitsPixel >> 3;
	BYTE *pBits = new BYTE[bi.bmWidth * bi.bmHeight * bpp];

	// Получаем битовый массив
	int  p = GetBitmapBits(maskBitmap, bi.bmWidth * bi.bmHeight * bpp, pBits);

	// Определяем цвет прозрачного символа
	TransPixel = *(DWORD*)pBits;

	TransPixel <<= 32 - bi.bmBitsPixel;

	// Цикл сканирования строк
	for (i = 0; i < bi.bmHeight; i++)
	{
		startx = -1;
		for (j = 0; j < bi.bmWidth; j++)
		{
			pixel = *(DWORD*)(pBits + (i * bi.bmWidth +
				j) * bpp) << (32 - bi.bmBitsPixel);
			if (pixel != TransPixel)
			{
				if (startx<0)
				{
					startx = j;
				}
				else if (j == (bi.bmWidth - 1))
				{
					Rgn = CreateRectRgn(startx, i, j, i + 1);
					CombineRgn(ResRgn, ResRgn, Rgn, RGN_OR);
					startx = -1;
				}
			}
			else if (startx >= 0)
			{
				Rgn = CreateRectRgn(startx, i, j, i + 1);
				CombineRgn(ResRgn, ResRgn, Rgn, RGN_OR);
				startx = -1;
			}
		}
	}

	delete pBits;
	SetWindowRgn(hWnd, ResRgn, TRUE);
	InvalidateRect(hWnd, 0, false);

	// организация цикла обработки сообщений
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int)msg.wParam;
}


ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);
	// регистрируем класс главного окна программы
	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_CLOCK3));
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = 0;
	wcex.lpszClassName = szWindowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}


BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	hInst = hInstance;

	hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, 0, 290, 540, NULL, NULL, hInstance, NULL);

	if (!hWnd)
	{
		return FALSE;
	}

	// Устанавливаем стрелки в положение соответствующие сисетмному времени
	SYSTEMTIME st; // используется для хранения времени: часа, минут, секунд и миллисекунд
	GetSystemTime(&st); // заполняет поля структуры SYSTEMTIME
	x -= st.wSecond * 6;
	y -= st.wMinute * 6 + st.wSecond*0.1;

	// Установливаем таймер
	TimmerID = SetTimer(hWnd, ID_5SECONDS, 1000, NULL);

	ShowWindow(hWnd, nCmdShow); // отобразить окно
	UpdateWindow(hWnd); // обновить окно


	return TRUE;
}


// функция главного окна программы
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;
	HDC hdcBits;

	switch (message)
	{
	case WM_PAINT:

		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...
		hdcBits = ::CreateCompatibleDC(hdc);
		SelectObject(hdcBits, maskBitmap);
		BitBlt(hdc, 0, 0, 280, 280, hdcBits, 0, 0, SRCCOPY);
		// SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_LAYERED); 
		// SetLayeredWindowAttributes(hWnd, 0, 220, LWA_ALPHA);

		{ // секундная стрелка
			HPEN hpen, hPenOld;
			hpen = CreatePen(PS_SOLID, 2, RGB(255, 100, 100));
			hPenOld = (HPEN)SelectObject(hdc, hpen);

			MoveToEx(hdc, 119, 119, NULL);
			LineTo(hdc, 119 + 95 * sin(3.1415926535*x / 180), 119 + 95 * cos(3.1415926535*x / 180));//119,35); 60 - dlin

			SelectObject(hdc, hPenOld);
			DeleteObject(hpen);
		}

		{ // минутная стрелка
			HPEN hpen, hPenOld;
			hpen = CreatePen(PS_SOLID, 3, RGB(80, 80, 80));
			hPenOld = (HPEN)SelectObject(hdc, hpen);

			MoveToEx(hdc, 119, 119, NULL);
			LineTo(hdc, 119 + 85 * sin(3.1415926535*y / 180), 119 + 85 * cos(3.1415926535*y / 180));//x,y);//155,65); // 85

			SelectObject(hdc, hPenOld);
			DeleteObject(hpen);
		}

		{ // заглушка в центре циферблата
			HPEN hpen, hPenOld;
			hpen = CreatePen(PS_SOLID, 3, RGB(170, 170, 170));
			hPenOld = (HPEN)SelectObject(hdc, hpen);
			HBRUSH hBrush, hBrushOld;
			hBrush = CreateSolidBrush(RGB(50, 0, 0));
			hBrushOld = (HBRUSH)SelectObject(hdc, hBrush);

			Ellipse(hdc, 113, 113, 125, 125);

			SelectObject(hdc, hBrushOld);
			DeleteObject(hBrush);
			SelectObject(hdc, hPenOld);
			DeleteObject(hpen);
		}

		DeleteDC(hdcBits);
		EndPaint(hWnd, &ps);
		break;

		// ----------------------TIMER-------------------------------
	case WM_TIMER: // обработка сообщения WM_TIMER
		if (x == -180) x = 180;
		x -= 180 / 30; // изменение угла секундной стрелки
		if (y == -180) y = 180;
		y -= 180 / 1800.0; // изменение угла минутной стрелки
		InvalidateRect(hWnd, 0, NULL);
		break;

	case WM_QUIT:
		KillTimer(hWnd, 1);  // уничтожение таймера
		break;

		// ---------------------END TIMER-----------------------------

	case WM_NCHITTEST:
	{
		return HTCAPTION;
	}

	case WM_NCRBUTTONUP:

	{
		PostQuitMessage(0);
	}

	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}