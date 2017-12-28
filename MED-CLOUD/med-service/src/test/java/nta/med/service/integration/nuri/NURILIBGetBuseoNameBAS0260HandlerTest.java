package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NURILIBGetBuseoNameBAS0260HandlerTest extends MessageRequestTest{
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NURILIBGetBuseoNameBAS0260Request request = NuriServiceProto.NURILIBGetBuseoNameBAS0260Request.newBuilder()
				.setBuseoGubun("3")
				.setGwa("PA")
				.setNaewonDate("2016/03/07")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
