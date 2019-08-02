public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        decimal quocient = (decimal) numerator / (decimal) denominator;
        String result = quocient.ToString();
        
        if(!isInteger(quocient) && isRecurring(numerator, denominator, quocient)) {
            return formatRecurringDecimal(result);
        }
        
        return result;        
    }
    
    private bool isInteger(decimal d) {
        return (d % 1) == 0;
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
    
    private String formatRecurringDecimal(String nonFormated) {
        String formated = nonFormated.Split('.')[0];
        String tail = nonFormated.Split('.')[1];
        
        int longestPeriod = 1;
        
        while(longestPeriod < tail.Length) {
            int testPeriod = longestPeriod + 1;
            int maxRepetitions = tail.Length/testPeriod;
                        
            if(generateRecurringNumber(tail, testPeriod, maxRepetitions) 
               != tail.Substring(0, testPeriod*maxRepetitions))
                break;
            
            longestPeriod = testPeriod;
        }
        
        formated += ".(" + tail.Substring(0, longestPeriod) + ")";
        return formated;
    }
    
    private String generateRecurringNumber(String number, int length, int repetitions) {
        String part = number.Substring(0, length);
        Console.WriteLine(part);
        String result = "";
        
        for(int i=0; i<=repetitions; i++) result += part;
        
        return result;
    }
}
