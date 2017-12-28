package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10GrdMagamPaQueryTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P10GrdMagamPaQueryRequest request = DrgsServiceProto.DRG3010P10GrdMagamPaQueryRequest.newBuilder()
		        .setFromDate("2012/1/1")
		        .setToDate("2015/1/1")
		        .setHoDong("T")
		        .setBunho("000040832")
		        .setMagamGubun("1")
		        .setPageNumber("")
		        .setOffset("")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
