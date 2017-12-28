package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P99grdListTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P99grdListRequest request = DrgsServiceProto.DRG3010P99grdListRequest.newBuilder()
				.setHoDong("T")
				.setBunho("000003227")
				.setFromDate("2011/05/31")
				.setToDate("2016/12/12")
				.setMagamGubun("%")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
