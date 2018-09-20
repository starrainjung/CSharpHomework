#include<iomanip>
#include<iostream>      
using namespace std;

struct Node1 {
	int Data[10];
	
	struct Node1 * next;
};
typedef struct Node1 Dlist;
struct Node2 {
	int Row, Col;

	Dlist * next;
};
typedef struct Node2 Hlist;


void  CreateTable(Hlist*& pH) {
	int i, j;
	Dlist *r = new Dlist();
	Hlist* h = new Hlist();
	cout << "��������������������"<<'\n';
	cin >> h->Row >> h->Col;               //ͷ���

	cout << "������ÿ�е����ݣ�����Ǻ�����ǰ��Ϊϵ������" << '\n';
	for (i = 0; i < h->Row; i++) {
		cout << "��" << i + 1 << "�У�";
		Dlist *s = new Dlist();
		for (j = 0; j < h->Col; j++) {
			cin >> s->Data[j];
		}
		if (h->next == NULL)
			h->next = s;
		else
			r->next = s;
		r = s;
	}
	r->next = NULL;
}

void DispList(Hlist*& h)
{
	int i;
	Dlist *p= h->next;
	while (p != NULL) {
		for (i = 0; i < h->Col; i++) {
			cout << p->Data[i] << '\n';
			p = p->next;
		}
	}
}

void LinkTable(Hlist*h1, Hlist*h2, Hlist *& ph) {
	int i, j, k;

	Dlist* p = h1->next; 

	Dlist *q = new Dlist();
	Dlist *r = new Dlist();

	cout << "�ֱ���Ҫ���ӵı���ţ�";
	cin >> i >> j;

	Hlist* h = new Hlist();
	h->Row = 0;
	h->Col = h1->Col + h2->Col;
	h->next = NULL;

	while (p != NULL) {
		q = h2->next;
		while (q!=NULL)
		{
			if(p->Data[i-1]==q->Data[j-1]){
			Dlist *s = new Dlist();
			for (k = 0;k < h1->Col; k++)
				s->Data[k]=p->Data[k];
			for (k = 0; k < h2->Col; k++)
				 s->Data[h1->Col+k]=q->Data[k];
			if (h->next == NULL)
				h->next = s;
			else
				r->next = s;
			r = s;
			h->Row++;
			}
			q = q->next;
		}
		p = p->next;
	}
	r->next = NULL;
}



int main() {
	Hlist *h1, *h2,*h;
	cout << "��1:" << '\n';
	CreateTable(h1);
	cout << "��2��" << '\n';
	CreateTable(h2);
	cout << "���ӽ����" << '\n';
	LinkTable(h1, h2, h);
    DispList(h);



	return 1;
}