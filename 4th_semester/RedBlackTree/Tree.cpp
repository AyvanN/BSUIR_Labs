#include <iostream>
#include "Node.cpp"

using namespace std;
template <typename keyType, typename dataType>

class Tree
{
public:
	Node<keyType, dataType>* root;
	Tree() :root(NULL){}
	void addNode(keyType new_key, dataType new_data)
	{
		Node<keyType, dataType>* new_node = NULL;
		if (root == NULL)
		{
			root = new Node<keyType, dataType>(NULL, new_key, new_data);
			new_node = root;
		}
		else
		{
			Node<keyType, dataType>* current_node = root;
			bool find_null = false;
			while (!find_null)
			{
				if (new_key > current_node->key)
				{
					if (current_node->right == NULL)
					{
						current_node->right = new Node<keyType, dataType>(current_node, new_key, new_data);
						new_node = current_node->right;
						find_null = true;
					}
					else
					{
						current_node = current_node->right;
					}
				}
				else
				{
					if (current_node->left == NULL)
					{
						current_node->left = new Node<keyType, dataType>(current_node, new_key, new_data);
						new_node = current_node->left;
						find_null = true;
					}
					else
					{
						current_node = current_node->left;
					}
				}
			}			
		}
		insertCaseOne(new_node);
	}
	void insertCaseOne(Node<keyType, dataType>* new_node)
	{
		if (new_node->parent == NULL)
		{
			new_node->color = BLACK;
		}			
		else
		{
			insertCaseTwo(new_node);
		}		
	}
	void insertCaseTwo(Node<keyType, dataType>* new_node)
	{
		if (new_node->parent->color == BLACK)
		{
			return;
		}	
		else
		{
			insertCaseThree(new_node);
		}			
	}
	void insertCaseThree(Node<keyType, dataType>* new_node)
	{
		Node<keyType, dataType>* u = uncle(new_node);
		if ((u != NULL) && (u->color == RED))
		{
			new_node->parent->color = BLACK;
			u->color = BLACK;
			Node<keyType, dataType>*  g = grandparent(new_node);
			g->color = RED;
			insertCaseOne(g);
		}
		else
		{
			insertCaseFour(new_node);
		}
	}
	void insertCaseFour(Node<keyType, dataType>* new_node)
	{
		Node<keyType, dataType>* g = grandparent(new_node);
		if ((new_node == new_node->parent->right) && (new_node->parent == g->left))
		{
			rotate_left(new_node->parent);
			new_node = new_node->left;
		}
		else
		{
			if ((new_node == new_node->parent->left) && (new_node->parent == g->right))
			{
				rotate_right(new_node->parent);
				new_node = new_node->right;
			}
		}
		insertCaseFive(new_node);
	}
	void insertCaseFive(Node<keyType, dataType>* new_node)
	{
		Node<keyType, dataType>* g = grandparent(new_node);
		new_node->parent->color = BLACK;
		g->color = RED;
		if ((new_node == new_node->parent->left) && (new_node->parent == g->left)) 
		{
			rotate_right(g);
		}
		else 
		{ 
			rotate_left(g);
		}
	}
	Node<keyType, dataType>* searchByKey(keyType need_key) 
	{
		if (root == NULL)
		{
			return NULL;
		}
		Node<keyType, dataType>* current = root;
		while (current != NULL) 
		{
			if (need_key == current->key)
			{
				return current;
			}
			if (need_key < current->key)
			{
				current = current->left;
			}
			else
			{
				current = current->right;
			}
		}
		return NULL;
	}
	void removeByKey(keyType need_key)
	{
		Node<keyType, dataType>* need_node = searchByKey(need_key);
		if (need_node->right != NULL && need_node->left != NULL)
		{
			Node<keyType, dataType>* rightmost = need_node->left;
			Node<keyType, dataType>* rightmostParent = need_node;
			while (rightmost->right != NULL) 
			{
				rightmostParent = rightmost;
				rightmost = rightmost->right;
			}
			need_node->key = rightmost->key;
			need_node->data = rightmost->data;
			deleteOneChild(rightmost);
		}
		else
		{
			deleteOneChild(need_node);
		}
	}
	void deleteOneChild(Node<keyType, dataType>* need_node)
	{
		Node<keyType, dataType>* child = need_node->left != NULL ? need_node->left : need_node->right;
		if (need_node->parent != NULL && need_node == need_node->parent->left)
		{
			if (child == NULL) 
			{
				if (need_node->parent != NULL)
				{
					need_node->parent->left = new Node<keyType, dataType>(need_node->parent, NULL, NULL);
					child = need_node->parent->left;
				}
				else root = NULL;
			}
			else 
			{
				if (need_node->parent != NULL)
				{
					need_node->parent->left = child;
				}
				else root = child;
			}
		}
		else 
		{
			if (child == NULL) 
			{
				if (need_node->parent != NULL)
				{
					need_node->parent->right = new Node<keyType, dataType>(need_node->parent, NULL, NULL);
					child = need_node->parent->right;
				}
				else root = NULL;
			}
			else 
			{
				if (need_node->parent != NULL)
				{
					need_node->parent->right = child;
				}
				else root = child;
			}
		}
		if (need_node->color == BLACK && child != NULL) 
		{
			if (child->color == RED)
			{
				child->color = BLACK;
			}
			else
			{
				deleteCaseOne(child);
			}			
		}
		if (child != NULL && child->key == NULL) 
		{
			if (child->parent == NULL) 
			{
				delete child;
				root = NULL;
			}
			else if (child->parent->left == child) 
			{
				Node<keyType, dataType>* temp = child->parent;
				delete child;
				temp->left = NULL;
			}
			else {
				Node<keyType, dataType>* temp = child->parent;
				delete child;
				temp->right = NULL;
			}
		}
		delete need_node;
	}
	void deleteCaseOne(Node<keyType, dataType>* need_node)
	{
		if (need_node->parent != NULL)
		{
			deleteCaseTwo(need_node);
		}
	}
	void deleteCaseTwo(Node<keyType, dataType>* need_node)
	{
		Node<keyType, dataType>* sib = sibling(need_node);
		if (sib->color == RED) 
		{
			need_node->parent->color = RED;
			sib->color = BLACK;
			if (need_node == need_node->parent->left)
			{
				rotate_left(need_node->parent);
			}	
			else
			{
				rotate_right(need_node->parent);
			}				
		}
		deleteCaseThree(need_node);
	}
	void deleteCaseThree(Node<keyType, dataType>* need_node)
	{
		Node<keyType, dataType>* sib = sibling(need_node);

		if ((need_node->parent->color == BLACK) &&
			(sib->color == BLACK) &&
			(sib->left->color == BLACK) &&
			(sib->right->color == BLACK))
		{
			sib->color = RED;
			deleteCaseOne(need_node->parent);
		}
		else
		{
			deleteCaseFour(need_node);
		}		
	}
	void deleteCaseFour(Node<keyType, dataType>* need_node)
	{
		Node<keyType, dataType>* sib = sibling(need_node);

		if ((need_node->parent->color == RED) &&
			(sib->color == BLACK) &&
			(sib->left->color == BLACK) &&
			(sib->right->color == BLACK))
		{
			sib->color = RED;
			need_node->parent->color = BLACK;
		}
		else
		{
			deleteCaseFive(need_node);
		}	
	}
	void deleteCaseFive(Node<keyType, dataType>* need_node)
	{
		Node<keyType, dataType>* sib = sibling(need_node);

		if (sib->color == BLACK)
		{
			if ((need_node == need_node->parent->left) &&
				(sib->right->color == BLACK) &&
				(sib->left->color == RED))
			{ 
				sib->color = RED;
				sib->left->color = BLACK;
				rotate_right(sib);
			}
			else if ((need_node == need_node->parent->right) &&
				(sib->left->color == BLACK) &&
				(sib->right->color == RED))
			{
				sib->color = RED;
				sib->right->color = BLACK;
				rotate_left(sib);
			}
		}
		deleteCaseSix(need_node);
	}
	void deleteCaseSix(Node<keyType, dataType>* need_node)
	{
		Node<keyType, dataType>* sib = sibling(need_node);

		sib->color = need_node->parent->color;
		need_node->parent->color = BLACK;

		if (need_node == need_node->parent->left)
		{
			sib->right->color = BLACK;
			rotate_left(need_node->parent);
		}
		else 
		{
			sib->left->color = BLACK;
			rotate_right(need_node->parent);
		}
	}
	Node<keyType, dataType>* predecessor(Node<keyType, dataType>* current_node)//предшественник
	{
		Node<keyType, dataType>* p;
		Node<keyType, dataType>* temp = current_node;
		if (temp->left != NULL)
		{
			temp = temp->left;
			while (temp->right != NULL)
			{
				temp = temp->right;
			}
			p = temp;
		}
		else
		{
			if (temp == temp->parent->right)
			{
				p = temp->parent;
			}
			else
			{
				if (temp->parent == temp->parent->parent->right)
				{
					p = temp->parent->parent;
				}				
				else
				{
					p = NULL;
				}
			}
		}
		return p;

	}
	Node<keyType, dataType>* successor(Node<keyType, dataType>* current_node)
	{
		Node<keyType, dataType>* s;
		Node<keyType, dataType>* temp = current_node;
		if (temp->right != NULL)
		{
			temp = temp->right;
			while (temp->left != NULL)
			{
				temp = temp->left;
			}
			s = temp;
		}
		else
		{ 
			if (temp == temp->parent->left)
			{
				s = temp->parent;
			}
			else
			{
				if (temp->parent == temp->parent->parent->left)
				{
					s = temp->parent->parent;
				}
				else
				{
					s = NULL;
				}
			}
		}
		return s;
	}
	Node<keyType, dataType>* grandparent(Node<keyType, dataType>* current_node)
	{
		if ((current_node != NULL) && (current_node->parent != NULL))
		{
			return current_node->parent->parent;
		}			
		else
		{
			return NULL;
		}			
	}
	Node<keyType, dataType>*  uncle(Node<keyType, dataType>* current_node)
	{
		Node<keyType, dataType>* g = grandparent(current_node);
		if (g == NULL)
		{
			return NULL; 
		}			
		if (current_node->parent == g->left)
		{
			return g->right;
		}			
		else
		{
			return g->left;
		}			
	}
	void rotate_left(Node<keyType, dataType>* current_node)
	{
		Node<keyType, dataType>* tParent = current_node->parent;
		Node<keyType, dataType>* tSwitch = current_node->right;
		Node<keyType, dataType>* tSChildLeft = tSwitch->left;
		if (tParent != NULL) 
		{
			if (current_node == tParent->left)
			{
				tParent->left = tSwitch;
			}
			else
			{
				tParent->right = tSwitch;
			}
			tSwitch->parent = tParent;
		}
		else 
		{
			root = tSwitch;
			tSwitch->parent = NULL;		
		}
		tSwitch->left = current_node;
		current_node->parent = tSwitch;
		current_node->right = tSChildLeft;
		if (tSChildLeft != NULL)
		{
			tSChildLeft->parent = current_node;
		}
	}
	void rotate_right(Node<keyType, dataType>* current_node)
	{
		Node<keyType, dataType>* tParent = current_node->parent;
		Node<keyType, dataType>* tSwitch = current_node->left;
		Node<keyType, dataType>* tSChildRight = tSwitch->right;
		if (tParent != NULL)
		{
			if (current_node == tParent->left)
			{
				tParent->left = tSwitch;
			}
			else
			{
				tParent->right = tSwitch;
			}
			tSwitch->parent = tParent;
			
		}
		else
		{
			root = tSwitch;
			tSwitch->parent = NULL;
		}
		tSwitch->right = current_node;
		current_node->parent = tSwitch;
		current_node->left = tSChildRight;
		if (tSChildRight != NULL)
		{
			tSChildRight->parent = current_node;
		}
	}
	Node<keyType, dataType>* sibling(Node<keyType, dataType>* current_node)
	{
		if (current_node == current_node->parent->left)
			return current_node->parent->right;
		else
			return current_node->parent->left;
	}
	void printNode(Node<keyType, dataType>* current_node)
	{
		if (current_node != 0)
		{
			cout << "Node " << current_node->key << "\n";
			cout << "Data: " << current_node->data << "\n";
			if (current_node->color == RED)
			{
				cout << "Color: red\n";
			}
			else
			{
				cout << "Color: black\n";
			}
		}
	}
	void printAll(Node<keyType, dataType>* current_node)
	{
		if (current_node == NULL)
		{
			return;
		}
		printNode(current_node);
		printAll(current_node->left);
		printAll(current_node->right);
	}
};
                                               
