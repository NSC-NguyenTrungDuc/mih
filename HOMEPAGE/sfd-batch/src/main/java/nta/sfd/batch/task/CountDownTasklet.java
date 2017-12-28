package nta.sfd.batch.task;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.batch.core.StepContribution;
import org.springframework.batch.core.scope.context.ChunkContext;
import org.springframework.batch.core.step.tasklet.Tasklet;
import org.springframework.batch.repeat.RepeatStatus;

import java.util.concurrent.CountDownLatch;

/**
 * @author dainguyen.
 */
public class CountDownTasklet implements Tasklet {
	private static final Logger LOG = LogManager.getLogger(CreateHospitalTasklet.class);
    private CountDownLatch countDownLatch;

    @Override
    public RepeatStatus execute(StepContribution contribution,
                                ChunkContext chunkContext) throws Exception {
    	LOG.debug("[START] Count down");
        countDownLatch.countDown();
        LOG.debug(countDownLatch.getCount());
        LOG.debug("[END] Count down");
        return RepeatStatus.FINISHED;
    }

    public void setCountDownLatch(CountDownLatch countDownLatch) {
        this.countDownLatch = countDownLatch;
    }
}
