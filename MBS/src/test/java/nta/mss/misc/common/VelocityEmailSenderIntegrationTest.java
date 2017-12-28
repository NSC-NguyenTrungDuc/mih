package nta.mss.misc.common;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import nta.mss.info.MailInfo;
import nta.mss.service.IMailService;

import org.junit.Ignore;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

/**
 * Created by: dainguyen.
 * Created date: 17/04/2014 2:52 PM.
 * Copyright: ©2014 XBID.VN Ltd. All Rights Reserved.
 */
@Ignore
@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration({"classpath:applicationContext.xml"})
public class VelocityEmailSenderIntegrationTest {
    @Autowired
    private IMailService mailService;
    
    /**
	 * Test send admin email.
	 * 
	 * @throws InterruptedException
	 *             the interrupted exception
	 */
    @Test
    public void testSendAdminEmail() throws InterruptedException {
        Map<String, Object> templateVariables = new HashMap<String, Object>();
//        template.setSubject("test");
//        template.setContent("${mailInfo.reservationCode");
        MailInfo mailInfo = new MailInfo();
        mailInfo.setReservationCode("21212122");
        mailInfo.setHospitalName("Kobari");
        mailInfo.setReservationDatetime("2014/07/16 15:42:00");
        templateVariables.put("mailInfo", mailInfo);
        
        List<String> toList = new ArrayList<>();
        toList.add("duyen.nguyen.thi@nextop.asia");
//        emailSender.sendMail(toList, template, templateVariables);
        Thread.sleep(10000);
    }
}
