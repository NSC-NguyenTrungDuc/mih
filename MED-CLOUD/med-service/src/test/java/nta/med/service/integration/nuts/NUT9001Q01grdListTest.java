package nta.med.service.integration.nuts;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUT9001Q01grdListTest extends MessageRequestTest{

	@Test
	public void test () throws Exception{
		
		NutsServiceProto.NUT9001Q01grdListRequest request = NutsServiceProto.NUT9001Q01grdListRequest.newBuilder()
				.setNutDate("2013/07/28")
				.setBldGubun("1")
				.setMagamSeq("1")
				.setHoDong("B")
				.build();
		sentRequestToMedApp(request, NutsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
