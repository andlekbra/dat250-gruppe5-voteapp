package no.hvl.dat250.gruppe5.voteapp.services;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import no.hvl.dat250.gruppe5.voteapp.models.DtoCreatePoll;
import no.hvl.dat250.gruppe5.voteapp.models.Poll;
import no.hvl.dat250.gruppe5.voteapp.models.PollTemplate;
import no.hvl.dat250.gruppe5.voteapp.models.VoteCount;
import no.hvl.dat250.gruppe5.voteapp.repository.PollRepository;
import no.hvl.dat250.gruppe5.voteapp.repository.PollTemplateRepository;

import java.util.List;

@Service
public class PollServices {

    private final PollRepository pollRepository;
    private final PollTemplateRepository pollTemplateRepository;

    @Autowired
    public PollServices(PollRepository pollRepository, PollTemplateRepository pollTemplateRepository) {
        this.pollRepository = pollRepository;
        this.pollTemplateRepository = pollTemplateRepository;
    }

    public Poll getPollbyId(Long pollId) {
        return pollRepository.findById(pollId)
                .orElseThrow(() -> new IllegalStateException("poll id" + pollId + " does not exist!"));
    }

    public Iterable<Poll> getAllPolls() {
        return pollRepository.findAll();
    }

    public void addNewPoll(DtoCreatePoll dtoCreatePoll) {
        PollTemplate pollTemplate = pollTemplateRepository.findById(dtoCreatePoll.getPollTemplateId())
                .orElseThrow(() -> new IllegalStateException(
                        "poll template id" + dtoCreatePoll.getPollTemplateId() + " does not exist!"));

        Poll poll = new Poll(dtoCreatePoll.getStartTime(), dtoCreatePoll.getStopTime(), 123, false,
                dtoCreatePoll.getName());

        poll.setPollTemplate(pollTemplate);

        pollTemplate.getPolls().add(poll);
        pollRepository.save(poll);
        pollTemplateRepository.save(pollTemplate);

    }

    public void addVotesToPoll(VoteCount voteCount, Long pollId) {
        Poll poll = pollRepository.findById(pollId)
                .orElseThrow(() -> new IllegalStateException("poll id" + pollId + " does not exist!"));

        poll.getVoteCounts().addVotes(voteCount);
        pollRepository.save(poll);
    }

    public List<Poll> getPollByTemplateId(Long templateId) {
        PollTemplate pollTemplate = pollTemplateRepository.findById(templateId)
                .orElseThrow(() -> new IllegalStateException("poll template id" + templateId + " does not exist!"));
        return pollTemplate.getPolls();
    }

}
