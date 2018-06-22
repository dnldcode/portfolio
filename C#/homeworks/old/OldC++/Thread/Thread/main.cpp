#include <Windows.h> 
#include <string> 

using namespace std;

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
const long N = 100000000;
long counter = 0;

DWORD WINAPI ThreadFunc(LPVOID lpv);
void IncCounter();
void DecCounter();
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
	wc.lpszMenuName = NULL;//wc.lpszMenuName = MAKEINTRESOURCE(IDR_MENU1); 
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
	HANDLE hThread;
	TCHAR text[100];


	switch (uMsg)
	{
	case WM_CLOSE:
		DestroyWindow(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		hThread = CreateThread(NULL, 0, ThreadFunc, NULL, 0, NULL);
		if (!hThread) {}
		DecCounter();
		WaitForSingleObject(hThread, INFINITE);
		InvalidateRect(hWnd, NULL, TRUE);
		break;
	case WM_PAINT:
		hDC = BeginPaint(hWnd, &psPaint);
		wsprintf(text, TEXT("count=%d"), counter);
		TextOut(hDC, 20, 20, text, lstrlen(text));
		EndPaint(hWnd, &psPaint);
		break;
	default:
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
	}
	return 0;
}	 

void IncCounter()
{
	for (int i = 0; i < N; i++)
	{
		//counter++; 
		InterlockedIncrement(&counter);
	}
}
void DecCounter()
{
	for (int i = 0;i < N; i++)
	{
		//counter--; 
		InterlockedDecrement(&counter);
	}
}
DWORD WINAPI ThreadFunc(LPVOID lpv)
{
	IncCounter();
	return 0;
}