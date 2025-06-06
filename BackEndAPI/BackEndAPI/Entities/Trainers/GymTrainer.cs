namespace BackEndAPI.Entities
{
    public class GymTrainer : Trainer
    {
        //foreign key Gym-trainer Membership
        public Trainer? Trainer { get; set; }
        public List<GymTrainerMembership> GymTrainerMemberships { get; set; } = new List<GymTrainerMembership>();

    }
} 