public class Solution {  
    public string FractionToDecimal(int numerator, int denominator) {
        float quocient = numerator/denominator;
        
        if(isRecurring(quocient)) {
            return formatRecurringDecimal(numerator, denominator);
        }
        else {
            return Float.toString(quocient);
        }
        
    }
    
    private boolean isRecurring(int numerator, int denominator) {
        float quocient = numerator/denominator;
        float sum = 0;
        
        for(int i=1; i <= denominator; i++) {
            sum += quocient;
        }
     
        if(sum == numerator)
            return false;
        
        return true;
    }
    
    private String formatRecurringDecimal(float number) {
        String nonFormated = Float.toString(number);
        String formated = nonFormated.split('.')[0];
        String tail = nonFormated.split('.')[1];
        
        int longestPeriod = 1;
        int tailSize = tail.length();
        
        while(longestPeriod < tailSize) {
            int testPeriod = longestPeriod + 1;
            int maxRepetitions = tailSize/testPeriod;
            String testDecimalPart = tail.substring(0, testPeriod);
            
            String testTail = generateRecurringNumber(testDecimalPart, maxRepetitions);
            if(testTail != tail.substring(0, testPeriod*maxRepetions))
                break;
            
            longestPeriod = testPeriod;
        }
        
        formated += "(" + tail.substring(0, longestPeriod) + ")";
    }
    
    private String generateRecurringNumber(String part, int repetitions) {
        String result = new String();
        
        for(int i=0; i<=repetitions; i++) result += part;
        
        return result;
    }
}
