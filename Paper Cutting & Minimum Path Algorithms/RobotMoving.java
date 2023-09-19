import java.util.Arrays;

//Cameron Rachman
//R00218886


public class RobotMoving {
	
	//Set costs
	private static double cost1[] = {1.1, 1.3, 2.5};
	private static double cost2[] = {1.5, 1.2, 2.3};
	
	public static void robMove(int n) {
		
		//Set and Initialise Matrixes
		double cost1Matrix[][] = new double[n][n];
		double cost2Matrix[][] = new double[n][n];
		cost1Matrix[0][0] = 0.0;
		cost2Matrix[0][0] = 0.0;
		
		String path1Matrix[][] = new String[n][n];		
		String path2Matrix[][] = new String[n][n];
		path1Matrix[0][0] = "";
		path2Matrix[0][0] = "";
		
		//If size less than or equal to zero show error
		if(n <= 0) {
			System.out.println("Error: Invalid parameter");
			return;
		}
		
		//Cost 1
		//Iniitialise the first row, column and diagonal with their costs and paths
		for(int i = 1; i < n; i++) {
			cost1Matrix[0][i] = cost1Matrix[0][i - 1] + cost1[0];	//Go right 
			path1Matrix[0][i] = path1Matrix[0][i - 1] + "Right, "; 
			
			cost1Matrix[i][0] = cost1Matrix[i - 1][0] + cost1[1];	//Go down
			path1Matrix[i][0] = path1Matrix[i - 1][0] + "Down, "; 
			
			cost1Matrix[i][i] = cost1Matrix[i - 1][i - 1] + cost1[2];	//Go diagonal
			path1Matrix[i][i] = path1Matrix[i - 1][i - 1] + "Diagonal, ";
		}
		
		//Calculate the minimum cost to reach finish point and record the path
		for(int i = 1; i < n; i++){
			for(int j = 1; j < n; j++) {
				double rightCost = cost1Matrix[i][j - 1] + cost1[0];
				double downCost = cost1Matrix[i - 1][j] + cost1[1];
				double diagonalCost = cost1Matrix[i - 1][j - 1] + cost1[2];

				//Determine the minimum cost and update the cost and path
                if (rightCost <= downCost && rightCost <= diagonalCost) {
                    cost1Matrix[i][j] = rightCost;
                    path1Matrix[i][j] = path1Matrix[i][j - 1] + "Right, "; 
                } else if (downCost <= rightCost && downCost <= diagonalCost) {
                    cost1Matrix[i][j] = downCost;
                    path1Matrix[i][j] = path1Matrix[i - 1][j] + "Down, "; 
                } else {
                    cost1Matrix[i][j] = diagonalCost;
                    path1Matrix[i][j] = path1Matrix[i - 1][j - 1] + "Diagonal, "; 
                }
			}
		}
		
		//Cost 2
		//Iniitialise the first row, column and diagonal with their costs and paths
		for(int i = 1; i < n; i++) {
			cost2Matrix[0][i] = cost2Matrix[0][i - 1] + cost2[0];	//Go right 
			path2Matrix[0][i] = path2Matrix[0][i - 1] + "Right, "; 
			
			cost2Matrix[i][0] = cost2Matrix[i - 1][0] + cost2[1];	//Go down
			path2Matrix[i][0] = path2Matrix[0][i - 1] + "Down, "; 
			
			cost2Matrix[i][i] = cost2Matrix[i - 1][i - 1] + cost2[2];	//Go diagonal
			path2Matrix[i][i] = path2Matrix[0][i - 1] + "Diagonal, "; 
		}
		
		//Calculate the minimum cost to reach finish point and record path
		for(int i = 1; i < n; i++){
			for(int j = 1; j < n; j++) {
				double rightCost = cost2Matrix[i][j - 1] + cost2[0];
				double downCost = cost2Matrix[i - 1][j] + cost2[1];
				double diagonalCost = cost2Matrix[i - 1][j - 1] + cost2[2];
				
				//Determine the minimum cost and update the cost and path
                if (rightCost <= downCost && rightCost <= diagonalCost) {
                    cost2Matrix[i][j] = rightCost;
                    path2Matrix[i][j] = path2Matrix[i][j - 1] + "Right, "; 
                } else if (downCost <= rightCost && downCost <= diagonalCost) {
                    cost2Matrix[i][j] = downCost;
                    path2Matrix[i][j] = path2Matrix[i - 1][j] + "Down, "; 
                } else {
                    cost2Matrix[i][j] = diagonalCost;
                    path2Matrix[i][j] = path2Matrix[i - 1][j - 1] + "Diagonal, "; 
                }
			}
		}
		
		//Variables for minimum costs and paths
		double cost1Minimum = cost1Matrix[n - 1][n - 1];
		double cost2Minimum = cost2Matrix[n - 1][n - 1];
        String path1Minimum = path1Matrix[n - 1][n - 1];
        String path2Minimum = path2Matrix[n - 1][n - 1];
		
        //Print costs and paths
		System.out.println("Minimum cost of reaching bottom left for Cost1 with matrix size " + n + ": " + cost1Matrix[n-1][n-1]);
		System.out.println("Path for Cost1: " + path1Minimum);
		
		System.out.println("Minimum cost of reaching bottom left for Cost2 with matrix size " + n + ": " + cost2Matrix[n-1][n-1]);
		System.out.println("Path for Cost2: " + path2Minimum);
		
		
	}

	public static void main(String[] args) {
		
		robMove(5);
		
		
	}

}
