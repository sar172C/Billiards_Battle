package typecheck;

public class Type {
	
	private String type;

    public Type(TerminalSymbol symbol) {this.type = symbol.toString();}

	public Type(Object objectType) {
		this.type = objectType.getClass().getName();
	}

	
	boolean equals(Type input) {
		if(this.getType().equals(input.getType())) return true;
		return false;
	}
	
	String getType() {
		return this.type;
	}
}
