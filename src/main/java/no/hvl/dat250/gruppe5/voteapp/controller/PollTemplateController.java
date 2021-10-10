package no.hvl.dat250.gruppe5.voteapp.controller;

import no.hvl.dat250.gruppe5.voteapp.models.PollTemplate;
import no.hvl.dat250.gruppe5.voteapp.services.PollTemplateService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping("/api/polltemplates/")
public class PollTemplateController {

    private final PollTemplateService pollTemplateService;

    @Autowired
    public PollTemplateController(PollTemplateService pollTemplateService){
        this.pollTemplateService = pollTemplateService;
    }

    @GetMapping(path = "/all")
    public Iterable<PollTemplate> getAllPollTemplates()
        {
            return pollTemplateService.getAllTemplates();
        }

    @GetMapping(path="/{pollTempId}")
    public Optional<PollTemplate> findPollTemplate(@RequestParam(value = "pollTempId") @PathVariable Long pollTempId){
        return pollTemplateService.getPollTemplateById(pollTempId);
    }
    /*
    @GetMapping
    public Iterable<PollTemplate> getAllPollTemplatesByVoterName(VoterProfile voter){
        return pollTemplateService.getAllTemplatesByVoter(voter);
    }
    */

    @PostMapping(path = "/create" )
    public HttpStatus createPollTemplate(@RequestBody PollTemplate pollTemplate){
        pollTemplateService.addNewPollTemplate(pollTemplate);
        return HttpStatus.OK;
    }

    @DeleteMapping
    public HttpStatus deletePollTemplateById(@RequestParam("pollTempId") Long pollTempId){
        pollTemplateService.deletePollTemplate(pollTempId);
        return HttpStatus.OK;
    }

}
