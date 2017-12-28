package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR0101U00layComboItemsTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		NuriServiceProto.NUR0101U00layComboItemsRequest request = NuriServiceProto.NUR0101U00layComboItemsRequest.newBuilder().build();
		
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
