namespace SimpleCalcAPI.Models {
    public class CalcResponse {
        public bool Success { get; set; }
        public string Error { get; set; }
        public int Value { get; set; }
    }
}