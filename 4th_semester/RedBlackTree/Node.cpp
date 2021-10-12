#include <cstddef>
enum nodeColor { BLACK, RED };

using namespace std;

template <typename keyType, typename dataType>
class Node
{
public:
	keyType key;
	dataType data;
	nodeColor color;
	Node<keyType, dataType>* left;
	Node<keyType, dataType>* right;
	Node<keyType, dataType>* parent;
	Node(Node<keyType,dataType>* p, keyType k, dataType d) :key(k),data(d)
	{
		color = RED;
		left = NULL;
		right = NULL;
		parent = p;
	}
};