#include <Windows.h>
#include <string>

using namespace std;

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
	wc.lpszMenuName = NULL;
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
	RECT rect;
	int nUserReply;
	HPEN hPen;
	HPEN hPenOld;
	HBRUSH hBrush;
	HBRUSH hBrushOld;
	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		DeleteObject(hPen);
		break;
	case WM_PAINT:
	{
		hDC = BeginPaint(hWnd, &psPaint);
		// Рисуем шахмотную доску
		int x1, x2;
		int y1 = 50, y2 = 100;
		for (int i = 0;i < 8;i++)
		{
			x1 = 50;
			x2 = 100;
			for (int z = 0; z < 8; z++)
			{
				if (z % 2 == 0 && i % 2 == 0 || z % 2 != 0 && i % 2 != 0)
					SelectObject(hDC, GetStockObject(WHITE_BRUSH));
				else
					SelectObject(hDC, GetStockObject(BLACK_BRUSH));
				Rectangle(hDC, x1, y1, x2, y2);
				x1 += 50;
				x2 += 50;
			}
			y1 += 50;
			y2 += 50;
		}
		EndPaint(hWnd, &psPaint);
		break;
	}
	case WM_CREATE:
		SetClassLong(hWnd, GCL_HBRBACKGROUND, (LONG)CreateSolidBrush(RGB(255, 255, 255)));
		break;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	return 0;
}