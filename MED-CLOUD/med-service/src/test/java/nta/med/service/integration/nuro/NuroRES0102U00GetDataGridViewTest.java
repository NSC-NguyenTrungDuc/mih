package nta.med.service.integration.nuro;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class NuroRES0102U00GetDataGridViewTest extends MessageRequestTest {
    @Test
    public void testNuroPatientGridView() throws InterruptedException {
    	NuroServiceProto.NuroRES0102U00GetDataGridViewRequest request = NuroServiceProto.NuroRES0102U00GetDataGridViewRequest.newBuilder().setHospCode("K01").setDoctor("01THUANTT").setDate("2016/02/11").build();
        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
    }
}
