package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3041P05grdIpgoJUSAOrderTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3041P05grdIpgoJUSAOrderRequest request = DrgsServiceProto.DRG3041P05grdIpgoJUSAOrderRequest.newBuilder()
				.setJubsuDate("1900/1/1")
				.setSerialV("102")
				.setDrgBunho("3004")
				.setPageNumber("")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
