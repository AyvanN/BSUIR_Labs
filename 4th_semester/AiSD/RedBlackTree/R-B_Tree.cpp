#include <iostream>
#include "Tree.cpp"
#include <chrono>


int main()
{
    Tree<int, int>* tree = new Tree<int, int>();
    auto start = std::chrono::system_clock::now();
    for (int i = 0; i < 1000000; i++)
    {
        tree->addNode(i, 100);
    }
    auto end = std::chrono::system_clock::now();
    std::chrono::duration<double> diff = end - start;
    std::cout << diff.count() << '\n';
    tree->printNode(tree->successor(tree->searchByKey(546)));
    tree->printNode(tree->predecessor(tree->searchByKey(546)));
}