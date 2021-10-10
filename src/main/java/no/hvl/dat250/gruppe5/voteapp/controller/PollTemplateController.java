package no.hvl.dat250.gruppe5.voteapp.controller;

import no.hvl.dat250.gruppe5.voteapp.models.PollTemplate;
import no.hvl.dat250.gruppe5.voteapp.models.VoterProfile;
import no.hvl.dat250.gruppe5.voteapp.services.PollTemplateService;
import no.hvl.dat250.gruppe5.voteapp.services.VoterProfileServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping(path = "api/polltemplates")
public class PollTemplateController {

    private final PollTemplateService pollTemplateService;
    private final VoterProfileServices voterService;

    @Autowired
    public PollTemplateController(PollTemplateService pollTemplateService,VoterProfileServices voterService){
        this.pollTemplateService = pollTemplateService;
        this.voterService = voterService;
    }

    @GetMapping
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
    public HttpStatus createPollTemplate(@RequestBody PollTemplate pollTemplate,@RequestParam(value = "voterId") Long voterId){
        Optional<VoterProfile> vp = voterService.getVoter(voterId);

        if(vp.isPresent()){
            pollTemplate.setVoter(vp.get());
            pollTemplateService.addNewPollTemplate(pollTemplate);
            return HttpStatus.OK;
        } else {
            return HttpStatus.NOT_FOUND;
        }


    }

    @DeleteMapping
    public HttpStatus deletePollTemplateById(@RequestParam("pollTempId") Long pollTempId){
        pollTemplateService.deletePollTemplate(pollTempId);

        return HttpStatus.OK;
    }

}
