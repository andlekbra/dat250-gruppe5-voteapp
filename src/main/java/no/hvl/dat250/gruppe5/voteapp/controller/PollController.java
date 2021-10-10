package no.hvl.dat250.gruppe5.voteapp.controller;

import org.springframework.web.bind.annotation.RestController;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

import no.hvl.dat250.gruppe5.voteapp.models.DtoCreatePoll;
import no.hvl.dat250.gruppe5.voteapp.models.Poll;
import no.hvl.dat250.gruppe5.voteapp.models.VoteCount;
import no.hvl.dat250.gruppe5.voteapp.services.PollServices;

import org.springframework.beans.factory.annotation.Autowired;

@RestController
@RequestMapping(path = "api/polls")
public class PollController {

    private final PollServices pollServices;

    @Autowired
    public PollController(PollServices pollServices) {
        this.pollServices = pollServices;
    }

    @GetMapping
    public Iterable<Poll> getPolls(@RequestParam(required = false) Long templateId) {
        if (templateId == null) {
            return pollServices.getAllPolls();
        } else {
            return pollServices.getPollByTemplateId(templateId);
        }
    }

    @GetMapping(path = "/{id}")
    public Poll findPollbyId(@PathVariable Long id) {
        return pollServices.getPollbyId(id);
    }

    @PostMapping
    public void registerNewPoll(@RequestBody DtoCreatePoll createPollCmd) {
        pollServices.addNewPoll(createPollCmd);
    }

    @PostMapping(path = "/{id}/votecount")
    public void addVotesToPoll(@RequestBody VoteCount voteCount, @PathVariable Long id) {
        pollServices.addVotesToPoll(voteCount, id);
    }

}
