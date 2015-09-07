using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArvoreRubroNegra
{
    public class RedBlackTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public static void Inserir(T valor)
        {
            RedBlackNode no = new RedBlackNode(valor);
        }

        private class RedBlackNode
        {
            private RedBlackNode _noEsquerda;
            private RedBlackNode _noDireita;
            private RedBlackNode _noRaiz;
            private readonly T _valorNo;
            private RedBlackNode _parentNodo;
            private int _qtdeNo;
            public NodeColor Cor { get; set; }
            public T NoRaiz
            {
                get { return _noRaiz.ValorNo; }
            }

            public int QtdeNo
            {
                get { return _qtdeNo; }
            }

            public Boolean IsVazio
            {
                get { return (_noRaiz == null); }
            }

            public Direction ParentDirection
            {
                get
                {
                    if (ParentNodo == null ||
                      ValorNo.CompareTo(ParentNodo.ValorNo) > 0)
                        return Direction.Esquerda;

                    return Direction.Direita;
                }
            }

            public T ValorNo
            {
                get { return _valorNo; }
            }

            public RedBlackNode ParentNodo
            {
                get { return _parentNodo; }
                set { _parentNodo = value; }
            }

            public RedBlackNode NoEsquerda
            {
                get { return _noEsquerda; }
                set { _noEsquerda = value; }
            }

            public RedBlackNode NoDireita
            {
                get { return _noDireita; }
                set { _noDireita = value; }
            }

            public Boolean IsRaiz
            {
                get { return (_parentNodo == null); }
            }

            public Boolean IsLeaf
            {
                get
                {
                    return (_noEsquerda == null && _noDireita == null);
                }
            }


            public RedBlackNode(T nodeValue)
                : this(nodeValue, null, null)
            {

            }

            public RedBlackNode(T nodeValue,
                  RedBlackNode left, RedBlackNode right)
            {
                _valorNo = nodeValue;
                Cor = NodeColor.Vermelho;
                _noEsquerda = left;
                _noDireita = right;
                _parentNodo = null;
            }

            public override string ToString()
            {
                return _valorNo.ToString();
            }

            public void Insert(T value)
            {
                if (_noRaiz == null)
                {
                    // In this case we are inserting the root node.
                    var node = new RedBlackNode(value) { ParentNodo = null, Cor = NodeColor.Preto };
                    _noRaiz = node;
                    _qtdeNo++;
                }
                else
                {
                    // The root already exists, so traverse the tree to figure out 
                    // where to put the node.
                    InsertNode(value, _noRaiz);
                }
            }

            public bool Contains(T value)
            {
                if (IsVazio)
                    return false;

                var current = _noRaiz;
                while (current != null)
                {
                    switch (value.CompareTo(current.ValorNo))
                    {
                        case -1:
                            current = current.NoEsquerda;
                            break;
                        case 1:
                            current = current.NoDireita;
                            break;
                        default:
                            return true;
                    }
                }

                // The item wasn't found.
                return false;
            }

            private void InsertNode(T value, RedBlackNode current)
            {
                if (value.CompareTo(current.ValorNo) == -1)
                {
                    if (current.NoEsquerda == null)
                    {
                        var node = new RedBlackNode(value)
                        {
                            Cor = NodeColor.Vermelho,
                            ParentNodo = current,
                        };
                        current.NoEsquerda = node;
                        _qtdeNo++;
                    }
                    else
                    {
                        InsertNode(value, current.NoEsquerda);
                        return;
                    }
                }
                else if (value.CompareTo(current.ValorNo) == 1)
                {
                    if (current.NoDireita == null)
                    {
                        var node = new RedBlackNode(value)
                        {
                            Cor = NodeColor.Vermelho,
                            ParentNodo = current,
                        };
                        current.NoDireita = node;
                        _qtdeNo++;
                    }
                    else
                    {
                        InsertNode(value, current.NoDireita);
                        return;
                    }
                }

                // Make sure we didn't violate the rules of a red/black tree.
                CheckNode(current);

                // Automatically make sure the root node is black. 
                _noRaiz.Cor = NodeColor.Preto;
            }

            private void CheckNode(RedBlackNode current)
            {
                if (current == null)
                    return;

                if (current.Cor != NodeColor.Vermelho) return;

                var uncleNode = GetSiblingNode(current);
                if (uncleNode != null && uncleNode.Cor == NodeColor.Vermelho)
                {
                    // Switch colors and then check grandparent.
                    uncleNode.Cor = NodeColor.Preto;
                    current.Cor = NodeColor.Preto;
                    current.ParentNodo.Cor = NodeColor.Vermelho;

                    // We don't have to check the root node, 
                    // I'm just going to turn it black.
                    if (current.ParentNodo.ParentNodo != null
                      && current.ParentNodo.ParentNodo.ValorNo.CompareTo(_noRaiz.ValorNo) != 0)
                    {
                        var node = current.ParentNodo.ParentNodo;
                        CheckNode(node);
                    }
                }
                else
                {
                    var redChild =
                      (current.NoEsquerda != null && current.NoEsquerda.Cor == NodeColor.Vermelho)
                           ? Direction.Esquerda : Direction.Direita;

                    // Need to rotate, figure out the node and direction for the rotation.
                    // There are 4 scenarios here, left child of right parent, 
                    // left child of left parent, right child of right parent, 
                    // right child of left parent
                    if (redChild == Direction.Esquerda)
                    {
                        if (current.ParentDirection == Direction.Direita)
                        {
                            RotateLeftChildRightParent(current);
                        }
                        else
                        {
                            RotateLeftChildLeftParent(current);
                        }
                    }
                    else
                    {
                        // Only do this if the right child is red, 
                        // otherwise no rotation is needed.
                        if (current.NoDireita.Cor == NodeColor.Vermelho)
                        {
                            if (current.ParentDirection == Direction.Direita)
                            {
                                RotateRightChildRightParent(current);
                            }
                            else
                            {
                                RotateRightChildLeftParent(current);
                            }
                        }
                    }
                }
            }

            private static RedBlackNode GetSiblingNode(RedBlackNode current)
            {
                if (current == null || current.ParentNodo == null)
                    return null;

                if (current.ParentNodo.NoEsquerda != null
                  && current.ParentNodo.NoEsquerda.ValorNo.CompareTo(current.ValorNo) == 0)
                    return current.ParentNodo.NoDireita;

                return current.ParentNodo.NoEsquerda;
            }

            private void FixChildColors(RedBlackNode current)
            {
                // If a node is red, both children must be black,switch if necessary.
                if (current.Cor == NodeColor.Vermelho)
                {
                    if (current.NoEsquerda != null
                        && current.NoEsquerda.Cor == NodeColor.Preto)
                    {
                        current.NoEsquerda.Cor = NodeColor.Vermelho;
                        current.Cor = NodeColor.Preto;
                    }
                    else if (current.NoDireita != null
                       && current.NoDireita.Cor == NodeColor.Preto)
                    {
                        current.NoDireita.Cor = NodeColor.Vermelho;
                        current.Cor = NodeColor.Preto;
                    }
                }
            }

            private void RotateRightChildRightParent(RedBlackNode current)
            {
                // Don't rotate on the root.
                if (current.IsRaiz)
                    return;

                var tmpNode = current.NoDireita.NoEsquerda;
                current.NoDireita.ParentNodo = current.ParentNodo;
                current.ParentNodo.NoEsquerda = current.NoDireita;
                current.ParentNodo = current.NoDireita;
                current.NoDireita.NoEsquerda = current;

                if (tmpNode != null)
                {
                    current.NoDireita = tmpNode;
                    tmpNode.ParentNodo = current;
                }
                else
                {
                    current.NoDireita = tmpNode;
                }

                // The new node to check is the parent node.
                var newCurrent = current.ParentNodo;
                CheckNode(newCurrent);
            }

            private void RotateLeftChildLeftParent(RedBlackNode current)
            {
                // Don't rotate on the root.
                if (current.IsRaiz)
                    return;

                var tmpNode = current.NoEsquerda.NoDireita;
                current.NoEsquerda.ParentNodo = current.ParentNodo;
                current.ParentNodo.NoDireita = current.NoEsquerda;
                current.ParentNodo = current.NoEsquerda;
                current.NoEsquerda.NoDireita = current;

                if (tmpNode != null)
                {
                    current.NoEsquerda = tmpNode;
                    tmpNode.ParentNodo = current;
                }
                else
                {
                    current.NoEsquerda = tmpNode;
                }

                // The new node to check is the parent node.
                var newCurrent = current.ParentNodo;
                CheckNode(newCurrent);
            }

            private void RotateLeftChildRightParent(RedBlackNode current)
            {
                // Don't rotate on the root.
                if (current.IsRaiz)
                    return;

                if (current.NoDireita != null)
                {
                    current.ParentNodo.NoEsquerda = current.NoDireita;
                    current.NoDireita.ParentNodo = current.ParentNodo;
                }
                else
                {
                    current.ParentNodo.NoEsquerda = current.NoDireita;
                }

                var tmpNode = current.ParentNodo.ParentNodo;
                current.NoDireita = current.ParentNodo;
                current.ParentNodo.ParentNodo = current;

                if (tmpNode == null)
                {
                    _noRaiz = current;
                    current.ParentNodo = null;
                }
                else
                {
                    current.ParentNodo = tmpNode;

                    // Make sure we have the pointer from the parent.
                    if (tmpNode.ValorNo.CompareTo(current.ValorNo) > 0)
                    {
                        tmpNode.NoEsquerda = current;
                    }
                    else
                    {
                        tmpNode.NoDireita = current;
                    }
                }

                FixChildColors(current);

                // The new node to check is the parent node.
                var newCurrent = current.ParentNodo;
                CheckNode(newCurrent);
            }

            private void RotateRightChildLeftParent(RedBlackNode current)
            {
                // Don't rotate on the root.
                if (current.IsRaiz)
                    return;

                if (current.NoEsquerda != null)
                {
                    current.ParentNodo.NoDireita = current.NoEsquerda;
                    current.NoEsquerda.ParentNodo = current.ParentNodo;
                }
                else
                {
                    current.ParentNodo.NoDireita = current.NoEsquerda;
                }

                var tmpNode = current.ParentNodo.ParentNodo;
                current.NoEsquerda = current.ParentNodo;
                current.ParentNodo.ParentNodo = current;

                if (tmpNode == null)
                {
                    _noRaiz = current;
                    current.ParentNodo = null;
                }
                else
                {
                    current.ParentNodo = tmpNode;

                    // Make sure we have the pointer from the parent.
                    if (tmpNode.ValorNo.CompareTo(current.ValorNo) > 0)
                    {
                        tmpNode.NoEsquerda = current;
                    }
                    else
                    {
                        tmpNode.NoDireita = current;
                    }
                }

                FixChildColors(current);

                // The new node to check is the parent node.
                var newCurrent = current.ParentNodo;
                CheckNode(newCurrent);
            }


        }
        public enum NodeColor
        {
            Vermelho = 0,
            Preto = 1
        }

        public enum Direction
        {
            Esquerda = 0,
            Direita = 1
        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        //

    }

}





