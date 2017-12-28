package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class CPL3020U02SetDataIFS7204HandlerTest extends MessageRequestTest{

    @Test
    public void testCPL3020U02SetDataIFS7204Request() throws Exception {

    	CplsServiceProto.CPL3020U02SetDataIFS7204Request request = CplsServiceProto.CPL3020U02SetDataIFS7204Request.newBuilder()
    			.setRecordGubun("re")
				.setSentaCode("se")
				.setIraiKey("ir")
				.setHangmogCode("ha")
				.setResultCode("re")
				.setSpecimenSer("sp")
				.setResultVal("re")
				.setDanui("da")
				.setFromStandard("fr")
				.setToStandard("to")
				.setEmergency("m")
				.setYobi1("yb1")
				.setFk("")
    			.build();

        sentRequestToMedApp(request, CplsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
