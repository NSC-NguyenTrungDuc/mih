package nta.med.service.intergration.ihis.phys;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.integration.MessageRequestTest;


public class PHY2001U04GrdPatientListTest extends MessageRequestTest {
    @Test
    public void testPHY2001U04GrdPatientList() throws InterruptedException {
    	PhysServiceProto.PHY2001U04GrdPatientListRequest request = PhysServiceProto.PHY2001U04GrdPatientListRequest
                .newBuilder()
                .setNaewonDate("2016/02/04")
                .setGwa("%")
                .setJubsuGubun("07")
                .setJinryoYn("ALL")
                .setNaewonYn("Y")
                .setSysId("PHYS")
                .build();

        sentRequestToMedApp(request, PhysServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
