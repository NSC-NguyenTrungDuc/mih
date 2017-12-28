package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10GrdPaDcTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P10GrdPaDcRequest request = DrgsServiceProto.DRG3010P10GrdPaDcRequest.newBuilder()
		        .setFromDate("2013/1/1")
		        .setToDate("2016/1/1")
		        .setBunho("000003227")
		        .setHoDong("T")
		        .setMagamGubun("N")
		        .setMagamBunryu("1")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
