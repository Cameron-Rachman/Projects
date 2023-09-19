import java.util.Arrays;

//Cameron Rachman
//R00218886


public class PaperRollCuttingBottomUp {

	//Set prices and lengths of rolls
	private static double prices[] = {0, 1.2, 3, 5.8, 10.1};
	private static int rollLengths[] = {0, 1, 2, 3, 5};
	
	public static void rollCutting(int length) {
		
		//If length less than or equal to zero show error
		if(length <= 0) {
			System.out.println("Error: Invalid parameter");
			return;
		}

		//Set array for optimal prices and a matrix to keep track of roll pieces
		double optimalPrices[] = new double[length + 1];
		int rollPieces[][] = new int [length+1][rollLengths.length];
		
		//Iterate over all roll lengths
		for(int i = 1; i <= length; i++) {
		double bestPrice = -1000;
			//Iterate over all types of roll pieces
			for(int j = 1; j < rollLengths.length; j++) {
				//Check if the current roll piece can be used for the current length of the paper roll
				if(rollLengths[j] <= i) {
					bestPrice = prices[j] + optimalPrices[i - rollLengths[j]];
					//If bestPrice is currently higher than optimal price at length
					if(bestPrice > optimalPrices[i]) {
						optimalPrices[i] = bestPrice;
						//Copy roll pieces from previous length to current one
						for(int k = 1; k < rollLengths.length; k++) {
							rollPieces[i][k] = rollPieces[i - rollLengths[j]][k];
						}
						rollPieces[i][j]++;
					}
				}
			}

		}
		
		//Print best price for length and no. of pieces of each type needed
		System.out.println("Best Price for length " + length + " is: " + optimalPrices[length]);
		System.out.println("Number of pieces of each type needed for best price:");
		for(int i = 1; i < rollLengths.length; i++) {
			System.out.println("Length " + rollLengths[i] + ": " + rollPieces[length][i]);
		}
		
		
	}


	public static void main(String[] args) {
		// TODO Auto-generated method stub
		rollCutting(11);
		
		
	}

}
