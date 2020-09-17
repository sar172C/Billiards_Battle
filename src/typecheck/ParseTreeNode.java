package typecheck;
import java.util.ArrayList;

/**
 * This class defines the structure of the parse tree that the type checker needs
 */

public class ParseTreeNode<T extends TypeCheckable>  {
    // stores the value of the part of the operation that is represented by this node
    private T value;
    private ParseTreeNode<T> childOne;
    private ParseTreeNode<T> childTwo;
    private ParseTreeNode<TerminalSymbol> operator;

    ParseTreeNode(T value) {this.value = value;}

    public T getValue() {
        return value;
    }

    public void setChildOne(ParseTreeNode<T> childOne) {
        this.childOne = childOne;
    }

    public void setChildTwo(ParseTreeNode<T> childTwo) {
        this.childTwo = childTwo;
    }

    public void setOperator(ParseTreeNode<TerminalSymbol> operator) {
        this.operator = operator;
    }

    public ParseTreeNode<T> getChildOne() {
        return childOne;
    }

    public ParseTreeNode<T> getChildTwo() {
        return childTwo;
    }

    public ParseTreeNode<TerminalSymbol> getOperator() {
        return operator;
    }

    /**
     * this method determines whether or not this node is a leaf node
     * @return whether or not this node is a leaf (has no children)
     */
    public boolean isLeaf() {
        // the check has to be in this order to short circuit so that a null pointer exception doesn't occur
        if( childOne == null && childTwo == null)
            return true;
        else
            return false;
    }
}
