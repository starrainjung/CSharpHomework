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
	cout << "请输入表的行数和列数："<<'\n';
	cin >> h->Row >> h->Col;               //头结点

	cout << "请输入每行的数据（如果是函数则前者为系数）：" << '\n';
	for (i = 0; i < h->Row; i++) {
		cout << "第" << i + 1 << "行：";
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

	cout << "分别需要连接的表序号：";
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
	cout << "表1:" << '\n';
	CreateTable(h1);
	cout << "表2：" << '\n';
	CreateTable(h2);
	cout << "连接结果：" << '\n';
	LinkTable(h1, h2, h);
    DispList(h);



	return 1;
}