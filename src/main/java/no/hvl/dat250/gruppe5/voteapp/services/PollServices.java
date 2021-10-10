package no.hvl.dat250.gruppe5.voteapp.services;

import org.springframework.beans.factory.annotation.Autowired;

import no.hvl.dat250.gruppe5.voteapp.models.Poll;
import no.hvl.dat250.gruppe5.voteapp.repository.PollRepository;

import java.util.Optional;

public class PollServices {

    private final PollRepository pollRepository;

    @Autowired
    public PollServices(PollRepository pollRepository) {
        this.pollRepository = pollRepository;
    }

    public Optional<Poll> getPoll(Long pollId) {
        return pollRepository.findById(pollId);
    }

    public void addNewPoll(Poll poll) {
        pollRepository.save(poll);
    }

}
