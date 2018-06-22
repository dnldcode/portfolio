#include<windows.h>
#include<string>
using namespace std;

#define UM_DONE WM_USER+1

struct trans
{
	HWND hwndParent;
    TCHAR name[30];
	int value;
};

trans TA, TB, TC;
DWORD WINAPI ThreadA(LPVOID);
DWORD WINAPI ThreadB(LPVOID);
DWORD WINAPI ThreadC(LPVOID);


LRESULT CALLBACK WndProc(HWND,UINT,WPARAM,LPARAM);
int WINAPI WinMain (
					HINSTANCE hInst,     // Дескриптор экземпляра приложения
					HINSTANCE hInstPrev, // Параметр для совместимости с Win 3.11
					LPSTR lpCmdLine,     // Указатель на командную строку
					int nCmdShow)		 // Каким образом будет отображено окно.
										 // стиль отображения окна
{
	HWND hwnd; //Дескриптор нашего окна главного приложения
	TCHAR szClassName[]=TEXT("МОЕ ОКНО"); //sz - 
	MSG msg;
	WNDCLASSEX wc;  // Создаем и заполняем структуру окна.
	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW;  //перерисовывать окно при изменениях его размеров
	wc.lpfnWndProc = WndProc;
	wc.cbClsExtra = 0; //всегда является 0 !!!
	wc.cbWndExtra = 0;
	wc.hInstance = hInst;
	wc.hIcon = LoadIcon(NULL,IDI_APPLICATION);  //Стандартрая иконка
	wc.hCursor = LoadCursor(NULL, IDC_ARROW); //Курсор - стрелка
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH); //Стандартная кисть
	wc.lpszMenuName = NULL; //Меню отсутствует
	wc.lpszClassName = szClassName;
	wc.hIconSm = LoadIcon(NULL,IDI_APPLICATION);  //Такая-же иконка в левом верхнем углу

// Регистрируем оконный класс

	if(!RegisterClassEx(&wc))
	{
		MessageBox(NULL,
			TEXT("Не удалось пройти регистрацию"),
			TEXT("Ошибка"),
			MB_OK);  //выбор кнопки
			return 0;
	}
// Cоздаем окно

	hwnd = CreateWindow(szClassName,		// Зарегистрированное имя окна
		TEXT("Коментарий - заголовок окна"),
		WS_OVERLAPPEDWINDOW,  // Стандартный набор для окна
		CW_USEDEFAULT, 0,   // Х и Y для начала окна (сейчас стоит по умолчанию)
		CW_USEDEFAULT, 0,   // Х и Y для размеров окна (сейчас стоит по умолчанию)
		NULL, // Дескриптор родительского окна, но у нас его нет, поэтому NULL
		NULL, // Дескриптор меню, но у нас его нет, поэтому NULL
		hInst, // Размещение в памяти нашего приложения
		NULL);

	if(!hwnd)
	{
		MessageBox(NULL,
		TEXT("Не удалось создать окно"),
		TEXT("Ошибка"),
		MB_OK);  //выбор кнопки
		return 0;
	}

// Отображаем созданное окно.
	ShowWindow(hwnd,nCmdShow);

// Цикл обработки сообщений.
	while(GetMessage(&msg,NULL,0,0))  //0,0 - означает обрабатывать все сообщения подряд
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg); //отправляет сообщение на обработку окна
	}
	return msg.wParam;
}


LRESULT CALLBACK WndProc(HWND hwnd,UINT uMsg,WPARAM wParam, LPARAM lParam)
{
	HDC hDC; // дескриптор контекста устройства
	PAINTSTRUCT ps; //рисовать
	RECT rect;  // для того, чтобы не перерисовывать все окно в результате его изменения

	static HANDLE hTA,hTB,hTC;
	static TCHAR buf[30];
	static int y=0;
	trans *ptm;
	

	switch (uMsg)
	{
	case WM_PAINT:
		hDC = BeginPaint(hwnd,&ps); //контекст устройства для рисования
		GetClientRect(hwnd, &rect); // клиентская область окна, в которой мы сможем рисовать
		TextOut(hDC, 50, y, buf, lstrlen(buf));
		EndPaint(hwnd, &ps);
		break;
	case WM_CLOSE:  // когда нужно закрыть окно.
		DestroyWindow(hwnd);  //функция, разрушающая окно
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		TA.hwndParent=hwnd;
		hTA=CreateThread(NULL,0,ThreadA,&TA, 0, NULL);
		
		if(!hTA)
		{
			MessageBox(hwnd, TEXT("проблемы с потоком а"),	TEXT("заголовок"), MB_OK);
			break;
		}
		

		TB.hwndParent=hwnd;
		hTB=CreateThread(NULL,0,ThreadB,&TB, 0, NULL);
		if(!hTB)
		{
			MessageBox(hwnd, TEXT("проблемы с потоком В"),	TEXT("заголовок"), MB_OK);
			break;
		}

		/*TC.hwndParent=hwnd;
		hTC=CreateThread(NULL,0,ThreadC,&TC, 0, NULL);
		if(!hTC)
		{
			MessageBox(hwnd, TEXT("Проблемы с потоком С"),	TEXT("заголовок"), MB_OK);
			break;
		}*/
		break;
	case UM_DONE:
		ptm=(trans*)wParam;
		wsprintf(buf,TEXT("%s : count = %d"), ptm->name, ptm->value);
		y=y+50;
		//MessageBox(hwnd,buf,TEXT(""),MB_OK);
		InvalidateRect(hwnd, NULL, FALSE);
		break;
	default:
		return DefWindowProc(hwnd,uMsg,wParam,lParam);
	}
	return 0;
}
DWORD WINAPI ThreadA(LPVOID lpv)
{
	trans * ptm = (trans*)lpv;
	int i, count = 0; 
	for(i=0;i<100000000;i++)
		count++;
	lstrcpy(ptm->name,TEXT("potok A"));
	ptm->value=count;
	SendMessage(ptm->hwndParent, UM_DONE, (WPARAM)ptm,0);
	return 0;
}
DWORD WINAPI ThreadB(LPVOID lpv)
{
	trans * ptm = (trans*)lpv;
	int i;
	int count = 0; 
 	for(i=0; i<20000000; i++)
		count++;
	lstrcpy(ptm->name,TEXT("potok B"));
	ptm->value=count;
	SendMessage(ptm->hwndParent, UM_DONE, (WPARAM)ptm,0);
	return 0;
}
DWORD WINAPI ThreadC(LPVOID lpv)
{
	trans * ptm = (trans*)lpv;
	int i, count = 0; 
	for(i=0;i<50000;i++)
		count++;
	lstrcpy(ptm->name,TEXT("potok C"));
	ptm->value=count;
	SendMessage(ptm->hwndParent, UM_DONE, (WPARAM)ptm,0);
	return 0;
}






