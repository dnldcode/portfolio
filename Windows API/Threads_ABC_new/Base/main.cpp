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
					HINSTANCE hInst,     // ���������� ���������� ����������
					HINSTANCE hInstPrev, // �������� ��� ������������� � Win 3.11
					LPSTR lpCmdLine,     // ��������� �� ��������� ������
					int nCmdShow)		 // ����� ������� ����� ���������� ����.
										 // ����� ����������� ����
{
	HWND hwnd; //���������� ������ ���� �������� ����������
	TCHAR szClassName[]=TEXT("��� ����"); //sz - 
	MSG msg;
	WNDCLASSEX wc;  // ������� � ��������� ��������� ����.
	wc.cbSize = sizeof(wc);
	wc.style = CS_HREDRAW | CS_VREDRAW;  //�������������� ���� ��� ���������� ��� ��������
	wc.lpfnWndProc = WndProc;
	wc.cbClsExtra = 0; //������ �������� 0 !!!
	wc.cbWndExtra = 0;
	wc.hInstance = hInst;
	wc.hIcon = LoadIcon(NULL,IDI_APPLICATION);  //����������� ������
	wc.hCursor = LoadCursor(NULL, IDC_ARROW); //������ - �������
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH); //����������� �����
	wc.lpszMenuName = NULL; //���� �����������
	wc.lpszClassName = szClassName;
	wc.hIconSm = LoadIcon(NULL,IDI_APPLICATION);  //�����-�� ������ � ����� ������� ����

// ������������ ������� �����

	if(!RegisterClassEx(&wc))
	{
		MessageBox(NULL,
			TEXT("�� ������� ������ �����������"),
			TEXT("������"),
			MB_OK);  //����� ������
			return 0;
	}
// C������ ����

	hwnd = CreateWindow(szClassName,		// ������������������ ��� ����
		TEXT("���������� - ��������� ����"),
		WS_OVERLAPPEDWINDOW,  // ����������� ����� ��� ����
		CW_USEDEFAULT, 0,   // � � Y ��� ������ ���� (������ ����� �� ���������)
		CW_USEDEFAULT, 0,   // � � Y ��� �������� ���� (������ ����� �� ���������)
		NULL, // ���������� ������������� ����, �� � ��� ��� ���, ������� NULL
		NULL, // ���������� ����, �� � ��� ��� ���, ������� NULL
		hInst, // ���������� � ������ ������ ����������
		NULL);

	if(!hwnd)
	{
		MessageBox(NULL,
		TEXT("�� ������� ������� ����"),
		TEXT("������"),
		MB_OK);  //����� ������
		return 0;
	}

// ���������� ��������� ����.
	ShowWindow(hwnd,nCmdShow);

// ���� ��������� ���������.
	while(GetMessage(&msg,NULL,0,0))  //0,0 - �������� ������������ ��� ��������� ������
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg); //���������� ��������� �� ��������� ����
	}
	return msg.wParam;
}


LRESULT CALLBACK WndProc(HWND hwnd,UINT uMsg,WPARAM wParam, LPARAM lParam)
{
	HDC hDC; // ���������� ��������� ����������
	PAINTSTRUCT ps; //��������
	RECT rect;  // ��� ����, ����� �� �������������� ��� ���� � ���������� ��� ���������

	static HANDLE hTA,hTB,hTC;
	static TCHAR buf[30];
	static int y=0;
	trans *ptm;
	

	switch (uMsg)
	{
	case WM_PAINT:
		hDC = BeginPaint(hwnd,&ps); //�������� ���������� ��� ���������
		GetClientRect(hwnd, &rect); // ���������� ������� ����, � ������� �� ������ ��������
		TextOut(hDC, 50, y, buf, lstrlen(buf));
		EndPaint(hwnd, &ps);
		break;
	case WM_CLOSE:  // ����� ����� ������� ����.
		DestroyWindow(hwnd);  //�������, ����������� ����
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CREATE:
		TA.hwndParent=hwnd;
		hTA=CreateThread(NULL,0,ThreadA,&TA, 0, NULL);
		
		if(!hTA)
		{
			MessageBox(hwnd, TEXT("�������� � ������� �"),	TEXT("���������"), MB_OK);
			break;
		}
		

		TB.hwndParent=hwnd;
		hTB=CreateThread(NULL,0,ThreadB,&TB, 0, NULL);
		if(!hTB)
		{
			MessageBox(hwnd, TEXT("�������� � ������� �"),	TEXT("���������"), MB_OK);
			break;
		}

		/*TC.hwndParent=hwnd;
		hTC=CreateThread(NULL,0,ThreadC,&TC, 0, NULL);
		if(!hTC)
		{
			MessageBox(hwnd, TEXT("�������� � ������� �"),	TEXT("���������"), MB_OK);
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






