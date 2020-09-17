package typecheck;

import java.util.List;
import java.util.Objects;

public enum TerminalSymbol implements TypeCheckable  {
	
	VARIABLE, PLUS, MINUS, TIMES, DIVIDE, OPEN, CLOSE;


	public Type getType() {
		return new Type(this.toString());
	}
	
}
