package no.hvl.dat250.gruppe5.voteapp.controller;

import org.springframework.web.bind.annotation.RestController;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

import no.hvl.dat250.gruppe5.voteapp.models.Poll;

import no.hvl.dat250.gruppe5.voteapp.services.PollServices;
import org.springframework.beans.factory.annotation.Autowired;
import java.util.Optional;

@RestController
@RequestMapping(path = "api/polls")
public class PollController {

    private final PollServices pollServices;

    @Autowired
    public PollController(PollServices pollServices) {
        this.pollServices = pollServices;
    }

    @GetMapping(path = "{pollId}")
    public Optional<Poll> findPollbyId(@PathVariable() Long pollId) {
        return pollServices.getPoll(pollId);
    }

    @PostMapping
    public void registerNewPoll(@RequestBody Poll poll) {
        pollServices.addNewPoll(poll);
    }

}
