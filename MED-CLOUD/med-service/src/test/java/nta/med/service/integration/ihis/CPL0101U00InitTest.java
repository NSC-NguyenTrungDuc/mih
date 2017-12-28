package nta.med.service.integration.ihis;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class CPL0101U00InitTest  extends MessageRequestTest{
	@Test
	public void testXRT9001R03Lay9003RRequest() throws InterruptedException {
       
    	CplsServiceProto.CPL0101U00InitRequest request = CplsServiceProto.CPL0101U00InitRequest.newBuilder()
        		.setTxtHangmog("")
        		.setIoGubun("00")
        		.build();
		sentRequestToMedApp(request, CplsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}