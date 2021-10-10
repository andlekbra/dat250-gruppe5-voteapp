package no.hvl.dat250.gruppe5.voteapp.loader;


//Small Databaseloader that loads the database with some examples
/*

@Component
public class DataBaseLoader implements CommandLineRunner {

    private final VoterProfileRepository repository;
    private final PollRepository repositoryPoll;
    private final PollTemplateRepository repositoryPollTemplate;

    @Autowired
    public DataBaseLoader(VoterProfileRepository repository, PollRepository repositoryPoll, PollTemplateRepository repositoryPollTemplate){
        this.repository = repository;
        this.repositoryPoll = repositoryPoll;
        this.repositoryPollTemplate = repositoryPollTemplate;

    }

    @Override
    public void run(String... args) throws Exception {
        this.repository.save(new VoterProfile("test1","test1@test_one.com","T","est1","qwerty_mcsmarty_pants1"));
        this.repository.save(new VoterProfile("test2","test2@test_two.com","T","est2","qwerty_mcsmarty_pants2"));
        this.repository.save(new VoterProfile("test3","test3@test_three.com","T","est3","qwerty_mcsmarty_pants3"));
        this.repository.save(new VoterProfile("test4","test4@test_four.com","T","est4","qwerty_mcsmarty_pants4"));

        this.repositoryPoll.save(new Poll(Time.valueOf(LocalTime.now()),Time.valueOf(LocalTime.now()), 123,false));
        this.repositoryPoll.save(new Poll(Time.valueOf(LocalTime.now()),Time.valueOf(LocalTime.now()), 456,false));

        this.repositoryPollTemplate.save(new PollTemplate("Test","Funker dette?", "Ja","Nei"));
        this.repositoryPollTemplate.save(new PollTemplate("Test2", "Hva med dette?","nei","nei"));


    }
}
*/