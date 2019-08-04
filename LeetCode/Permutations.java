class Solution {
    public List<List<Integer>> permute(int[] nums) {
        List<Integer> numsAsList = new ArrayList<Integer>();
        
        for(int i=0; i<nums.length; i++) {
            numsAsList.add(new Integer(nums[i]));
        }
        
        List<List<Integer>> permutations =       
            permute(new ArrayList<List<Integer>>(),
                    new ArrayList<Integer>(),
                    numsAsList);              

        return permutations;
    }
    
    private List<List<Integer>> permute(
        List<List<Integer>> permutations,
        List<Integer> head, 
        List<Integer> tail) {
                
        if(tail.size() == 0)
            permutations.add(head);

        for (Integer member : tail) {
            List<Integer> newHead = new ArrayList<Integer>(head);
            newHead.add(member);

            List<Integer> newTail = new ArrayList<Integer>(tail);
            newTail.remove(member);

            return permute(permutations, newHead, newTail);
        }
        
        return permutations;
    }
}

// https://leetcode.com/problems/permutations/
