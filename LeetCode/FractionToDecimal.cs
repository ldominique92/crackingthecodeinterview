public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        decimal quocient = (decimal) numerator / (decimal) denominator;
        
        if(isRecurring(numerator, denominator, quocient)) {
            return formatRecurringDecimal(quocient);
        }
        else {
            return quocient.ToString();
        }
        
    }
    
    private bool isRecurring(int numerator, int denominator, decimal quocient) {
        decimal sum = 0;
        
        for(int i=1; i <= denominator; i++) {
            sum += quocient;
        }
     
        if(sum == numerator)
            return false;
        
        return true;
    }
    
    private String formatRecurringDecimal(decimal number) {
        String nonFormated = number.ToString();
        String formated = nonFormated.Split('.')[0];
        String tail = nonFormated.Split('.')[1];
        
        int longestPeriod = 1;
        int tailSize = tail.Length;
        
        while(longestPeriod < tailSize) {
            int testPeriod = longestPeriod + 1;
            int maxRepetitions = tailSize/testPeriod;
            String testDecimalPart = tail.Substring(0, testPeriod);
            
            String testTail = generateRecurringNumber(testDecimalPart, maxRepetitions);
            if(testTail != tail.Substring(0, testPeriod*maxRepetitions))
                break;
            
            longestPeriod = testPeriod;
        }
        
        formated += ".(" + tail.Substring(0, longestPeriod) + ")";
        return formated;
    }
    
    private String generateRecurringNumber(String part, int repetitions) {
        String result = "";
        
        for(int i=0; i<=repetitions; i++) result += part;
        
        return result;
    }
}
