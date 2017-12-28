package nta.med.service.integration.cpls;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class CPL7001Q01LayDailyReportTest extends MessageRequestTest {
    @Test
    public void testCPL7001Q01LayDailyReport() throws Exception {

        CplsServiceProto.CPL7001Q01LayDailyReportRequest request = CplsServiceProto.CPL7001Q01LayDailyReportRequest.newBuilder()
                .setKensaDate("2015/12/11")
                .setIoGubun("%")
                .setUitakCode("%")
                .build();

        sentRequestToMedApp(request, CplsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
