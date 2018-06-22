#include <Windows.h>
#include <string>
#include <vector>
#include <time.h>

using namespace std;

class Point
{
public:
	int x;
	int y;
	Point(int x = 0, int y = 0)
	{
		this->x = x;
		this->y = y;
	}
};

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hInstPrev, LPSTR lpCmdLine, int nCmdShow)// LP - LongPointer(указат на данные), H - Handle
{
	srand(time(NULL));
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
	HDC hDC1;
	static HDC hDC;// Handler device context
	static int x, y;
	TCHAR text[100];
	RECT rect;
	PAINTSTRUCT psPaint;
	static BOOL flag = false;
	static vector<Point> line;
	static vector< vector<Point> > lines;
	vector <Point>::iterator it;
	HPEN hPen;
	static HPEN hPenOld;

	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		ReleaseDC(hWnd, hDC);
		break;
	case WM_CREATE:
		hDC = GetDC(hWnd);
		hPenOld = (HPEN)SelectObject(hDC, GetStockObject(DC_PEN));
		CreatePen(PS_DASH, 5, RGB(250, 50, 180));
		SetDCPenColor(hDC, RGB(rand() % 256, rand() % 256, rand() % 256));
		break;
	case WM_LBUTTONDOWN:
		flag = true;
		x = LOWORD(lParam);
		y = HIWORD(lParam);
		MoveToEx(hDC, x, y, NULL);
		line.push_back(Point(x, y));
		break;
	case WM_LBUTTONUP:
		if (flag)
		{
			flag = false;
			lines.push_back(line);
			line.clear();
		}
		//SelectObject(hDC, hPenOld);
		break;
	case WM_MOUSEMOVE:
		if (flag)
		{
			x = LOWORD(lParam);
			y = HIWORD(lParam);
			LineTo(hDC, x, y);
			line.push_back(Point(x, y));
		}
		//InvalidateRect(hWnd, NULL, true);
		break;
	case WM_PAINT:
		hDC1 = BeginPaint(hWnd, &psPaint);
		(HPEN)SelectObject(hDC1, GetStockObject(DC_PEN));
		for (int i = 0;i < lines.size();i++)
		{
			SetDCPenColor(hDC1, GetDCPenColor(hDC));
			it = lines[i].begin();
			MoveToEx(hDC1, it->x, it->y, NULL);
			for (it + 1; it != lines[i].end();it++)
				LineTo(hDC1, it->x, it->y);
		}
		EndPaint(hWnd, &psPaint);
		break;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	return 0;
}