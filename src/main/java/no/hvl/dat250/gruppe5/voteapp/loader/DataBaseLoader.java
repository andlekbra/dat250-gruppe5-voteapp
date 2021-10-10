package no.hvl.dat250.gruppe5.voteapp.loader;


import no.hvl.dat250.gruppe5.voteapp.models.Poll;
import no.hvl.dat250.gruppe5.voteapp.models.PollTemplate;
import no.hvl.dat250.gruppe5.voteapp.models.VoterProfile;
import no.hvl.dat250.gruppe5.voteapp.repository.PollRepository;
import no.hvl.dat250.gruppe5.voteapp.repository.PollTemplateRepository;
import no.hvl.dat250.gruppe5.voteapp.repository.VoterProfileRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import java.sql.Time;
import java.time.LocalTime;

//Small Databaseloader that loads the database with some examples


@Component
public class DataBaseLoader implements CommandLineRunner {

        private final VoterProfileRepository repository;
        private final PollRepository repositoryPoll;
        private final PollTemplateRepository repositoryPollTemplate;

        @Autowired
        public DataBaseLoader(VoterProfileRepository repository, PollRepository repositoryPoll,
                        PollTemplateRepository repositoryPollTemplate) {
                this.repository = repository;
                this.repositoryPoll = repositoryPoll;
                this.repositoryPollTemplate = repositoryPollTemplate;

        }

        @Override
        public void run(String... args) throws Exception {
                if (true) {
                        this.repository.save(new VoterProfile("test1", "test1@test_one.com", "T", "est1",
                                        "qwerty_mcsmarty_pants1"));
                        this.repository.save(new VoterProfile("test2", "test2@test_two.com", "T", "est2",
                                        "qwerty_mcsmarty_pants2"));
                        this.repository.save(new VoterProfile("test3", "test3@test_three.com", "T", "est3",
                                        "qwerty_mcsmarty_pants3"));
                        this.repository.save(new VoterProfile("test4", "test4@test_four.com", "T", "est4",
                                        "qwerty_mcsmarty_pants4"));

                        Poll poll1 = new Poll(Time.valueOf(LocalTime.now()), Time.valueOf(LocalTime.now()), 123, false,
                                        "name1");
                        Poll poll2 = new Poll(Time.valueOf(LocalTime.now()), Time.valueOf(LocalTime.now()), 456, false,
                                        "name2");

                        PollTemplate pollTemplate1 = new PollTemplate("Test", "Funker dette?", "Ja", "Nei");
                        PollTemplate polltemplate2 = new PollTemplate("Test2", "Hva med dette?", "nei", "nei");

                        this.repositoryPollTemplate.save(pollTemplate1);
                        this.repositoryPollTemplate.save(polltemplate2);

                        poll1.setPollTemplate(pollTemplate1);
                        poll2.setPollTemplate(polltemplate2);

                        this.repositoryPoll.save(poll1);
                        this.repositoryPoll.save(poll2);

                        // pollTemplate1.getPolls().add(poll1);
                        // polltemplate2.getPolls().add(poll2);

                        this.repositoryPollTemplate.save(pollTemplate1);
                        this.repositoryPollTemplate.save(polltemplate2);

                }
        }
}
*/