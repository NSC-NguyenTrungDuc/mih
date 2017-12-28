package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3041P05grdMixListTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3041P05grdMixListRequest request = DrgsServiceProto.DRG3041P05grdMixListRequest.newBuilder()
				.setBunryu1("1")
				.setHoDong("T")
				.setIpgoDate("2016/1/21")
				.setBunho("000000001")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
