package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P99grdPaDcListTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P99grdPaDcListRequest request = DrgsServiceProto.DRG3010P99grdPaDcListRequest.newBuilder()
				.setHoDong("T3")
				.setBunho("000009254")
				.setFromDate("2011/05/31")
				.setToDate("2016/12/12")
				.setMagamGubun("%")
				.build();
		
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
