package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP2004Q01grdINP2004Test extends MessageRequestTest{

	@Test
	public void test() throws InterruptedException{
		InpsServiceProto.INP2004Q01grdINP2004Request request = InpsServiceProto.INP2004Q01grdINP2004Request.newBuilder()
				.setHospCode("323")
				.setFromDate("1999/01/01")
				.setToDate("2019/01/01")
				.setOffset("")
				.build();
		
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
