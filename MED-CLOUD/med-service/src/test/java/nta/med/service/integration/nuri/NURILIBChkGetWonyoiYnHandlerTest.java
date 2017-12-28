package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NURILIBChkGetWonyoiYnHandlerTest extends MessageRequestTest{
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NURILIBChkGetWonyoiYnRequest request = NuriServiceProto.NURILIBChkGetWonyoiYnRequest.newBuilder()
				.setBunho("000000001")
				.setJubsuTime("1240")
				.setNaewonDate("2016/03/07")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
