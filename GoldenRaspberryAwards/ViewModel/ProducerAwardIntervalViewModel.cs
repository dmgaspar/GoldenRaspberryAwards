namespace GoldenRaspberryAwards.ViewModel
{
    public class ProducerAwardIntervalViewModel
    {
        private List<AwardViewModel> min = new List<AwardViewModel>();

        private List<AwardViewModel> max = new List<AwardViewModel>();

        public List<AwardViewModel> Min
        {
            get { return min; }
            set { min = value; }
        }

        public List<AwardViewModel> Max
        {
            get { return max; }
            set { max = value; }
        }
    }
}
