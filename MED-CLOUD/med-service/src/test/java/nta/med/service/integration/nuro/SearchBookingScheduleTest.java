package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author DEV-TiepNM
 */
public class SearchBookingScheduleTest extends MessageRequestTest {
    @Test
    public void test() throws InterruptedException{
        NuroServiceProto.SearchBookingScheduleRequest request = NuroServiceProto.SearchBookingScheduleRequest
                .newBuilder()
                .setHospCode("323")
                .setDepartment("01")
                .setStartDate("20160808")
                .setEndDate("20160814")
                .build();
        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }
}
